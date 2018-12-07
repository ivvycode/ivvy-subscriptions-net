using System;
using System.IO;
using System.Text;
using System.Collections.Generic;
using System.Threading.Tasks;
using System.Security.Cryptography;
using System.Security.Cryptography.X509Certificates;
using Newtonsoft.Json;
using Org.BouncyCastle.Crypto;
using Org.BouncyCastle.Crypto.Parameters;
using Org.BouncyCastle.OpenSsl;
using Org.BouncyCastle.Security;
using Ivvy.Subscriptions.Messages.Venues.Bookings;

namespace Ivvy.Subscriptions
{
    /// <summary>
    /// This class represents a single message that can be received from iVvy's
    /// account subscription notifications.
    /// </summary>
    public class Message
    {
        /// <summary>
        /// The unique transaction id of the message.
        /// </summary>
        [JsonProperty("TxnId")]
        public string TxnId { get; set; }

        /// <summary>
        /// The application region from which the message was sent.
        /// </summary>
        [JsonProperty("Region")]
        public string Region { get; set; }

        /// <summary>
        /// The UTC timestamp when the message was sent.
        /// </summary>
        [JsonProperty("Timestamp")]
        public int Timestamp { get; set; }

        /// <summary>
        /// The unique id of the iVvy account within the application region.
        /// </summary>
        [JsonProperty("AccountId")]
        public string AccountId { get; set; }

        /// <summary>
        /// The notification message subject.
        /// </summary>
        [JsonProperty("Subject")]
        public string Subject { get; set; }

        /// <summary>
        /// The json encoded string of data that depends on the message subject.
        /// </summary>
        [JsonProperty("Body")]
        public string Body { get; set; }

        /// <summary>
        /// The message signature, which must be validated before handling the message.
        /// </summary>
        [JsonProperty("Signature")]
        public string Signature { get; set; }

        /// <summary>
        /// The path to the public key that can be used to verify the signature.
        /// </summary>
        [JsonProperty("SigningPublicKeyPath")]
        public string SigningPublicKeyPath { get; set; }

        /// <summary>
        /// Parses a json string, and returns a message object.
        /// </summary>
        public static Message ParseMessage(string messageText)
        {
            return JsonConvert.DeserializeObject<Message>(messageText);
        }

        /// <summary>
        /// Decodes the message body into a known iVvy message.
        /// </summary>
        public object DecodeBody()
        {
            if (Subject == null || Subject == "" || Body == null || Body == "") {
                return null;
            }
            switch (Subject) {
                case "BookingAdded":
                    return TryDecodeBody<BookingAdded>(Body);

                case "BookingUpdated":
                    return TryDecodeBody<BookingUpdated>(Body);

                case "BookingDeleted":
                    return TryDecodeBody<BookingDeleted>(Body);

                case "BookingAccommodationAdded":
                    return TryDecodeBody<AccommodationAdded>(Body);

                case "BookingAccommodationUpdated":
                    return TryDecodeBody<AccommodationUpdated>(Body);

                case "BookingAccommodationDeleted":
                    return TryDecodeBody<AccommodationDeleted>(Body);

                case "BookingRoomReservationAdded":
                    return TryDecodeBody<RoomReservationAdded>(Body);

                case "BookingRoomReservationUpdated":
                    return TryDecodeBody<RoomReservationUpdated>(Body);

                case "BookingRoomReservationConfirmed":
                    return TryDecodeBody<RoomReservationConfirmed>(Body);

                case "BookingRoomReservationCancelled":
                    return TryDecodeBody<RoomReservationCancelled>(Body);

                case "BookingRoomReservationDeleted":
                    return TryDecodeBody<RoomReservationDeleted>(Body);

                default:
                    return null;
            }
        }

        /// <summary>
        /// Does the actual work of deserializing the message body.
        /// </summary>
        private object TryDecodeBody<T>(string json) where T : new()
        {
            try {
                return JsonConvert.DeserializeObject<T>(json, new JsonSerializerSettings {
                    DateTimeZoneHandling = DateTimeZoneHandling.Utc,
                    DateFormatString = Ivvy.Utils.DateTimeFormat,
                    DateParseHandling = DateParseHandling.DateTime,
                });
            }
            catch (Exception ex) {
                return null;
            }
        }

        /// <summary>
        /// Validates this message's signature.
        /// <param name="publicKeyCache">Keys matching the signature path will be used, avoiding a http request to fetch the public key.</param>
        /// <param name="receivedPublicKey">Called with the public key details, to allow calling code to store for later.</param>
        /// </summary>
        public async Task<bool> IsSignatureValidAsync(
            Dictionary<string, string> publicKeyCache,
            Func<string, string, Task> receivedPublicKey)
        {
            string strToSign = GetStringToSign();
            string publicKey = await FetchPublicKey(publicKeyCache);
            if (publicKey == null) {
                return false;
            }
            if (receivedPublicKey != null) {
                await receivedPublicKey(SigningPublicKeyPath, publicKey);
            }
            var pemObject = new PemReader(new StringReader(publicKey)).ReadObject() as RsaKeyParameters;
            var parameters = DotNetUtilities.ToRSAParameters(pemObject);
            RSACryptoServiceProvider rsa = new RSACryptoServiceProvider();
            rsa.ImportParameters(parameters);
            return rsa.VerifyData(
                Encoding.UTF8.GetBytes(strToSign),
                CryptoConfig.MapNameToOID("SHA1"),
                Convert.FromBase64String(Signature)
            );
        }

        /// <summary>
        /// Returns this message's string to sign.
        /// </summary>
        private string GetStringToSign()
        {
            string bodyHash = "";
            using (var sha1 = SHA1.Create()) {
                byte[] hashBytes = sha1.ComputeHash(Encoding.UTF8.GetBytes(Body));
                bodyHash = Ivvy.Utils.BytesToString(hashBytes);
            }
            string[] parts = {
                TxnId == null ? "" : TxnId,
                Region == null ? "" : Region,
                Timestamp.ToString(),
                AccountId == null ? "" : AccountId,
                Subject == null ? "" : Subject,
                bodyHash
            };
            return String.Join(":", parts).ToLower();
        }

        /// <summary>
        /// Returns the public key used to verify this message's signature.
        /// <param name="publicKeyCache">Keys matching the signature path will be used, avoiding a http request to fetch the public key.</param>
        /// </summary>
        private async Task<string> FetchPublicKey(Dictionary<string, string> publicKeyCache)
        {
            if (SigningPublicKeyPath == null) {
                return null;
            }
            if (publicKeyCache != null && publicKeyCache.ContainsKey(SigningPublicKeyPath)) {
                return publicKeyCache[SigningPublicKeyPath];
            }
            string publicKeyUrl = GetPublicKeyUrl();
            if (publicKeyUrl == null) {
                return null;
            }
            try {
                return await Utils.MakeGetRequest(publicKeyUrl);
            }
            catch (Exception ex) {
                return null;
            }
        }

        /// <summary>
        /// Returns the url of the public key used to verify this message's signature.
        /// </summary>
        private string GetPublicKeyUrl()
        {
            if (SigningPublicKeyPath == null || Region == null) {
                return null;
            }
            string basePath = "";
            if (Region == "stage") {
                basePath = "https://s3-ap-southeast-2.amazonaws.com/notifications.stageau.ap-southeast-2.ivvy.com";
            }
            else {
                basePath = $"https://s3-{Region}.amazonaws.com/accountnotifications.{Region}.ivvy.com";
            }
            return basePath + SigningPublicKeyPath;
        }
    }
}
