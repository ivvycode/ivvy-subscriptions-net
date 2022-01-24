using System;
using System.Collections.Generic;
using System.IO;
using System.Threading.Tasks;

namespace Ivvy.Subscriptions.Handler
{
    /// <summary>
    /// This class can be used to handle subscription notification messages from iVvy.
    /// </summary>
    public class MessageHandler
    {
        /// <summary>
        /// Implementation of the message decoder. The default implementation uses AWS, but
        /// an alternative may be provided at construction time.
        /// </summary>
        private readonly IMessageDecoder messageDecoder;

        /// <summary>
        /// Keys matching the signature path will be used, avoiding a http request to fetch the public key.
        /// </summary>
        private readonly Dictionary<string, string> publicKeyCache;

        /// <summary>
        /// Callback that can be used to store the public key details for quicker access later.
        /// </summary>
        private readonly Func<string, string, Task> receivedPublicKey;

        /// <summary>
        /// This class can be used to handle subscription notification messages from iVvy.
        /// If the messages are delivered as AWS subscription messages (the default case) this
        /// interface validates the AWS topic.
        /// <param name="isTopicValid">Callback used to validate the message topic.</param>
        /// <param name="publicKeyCache">Keys matching the signature path will be used, avoiding a http request to fetch the public key.</param>
        /// <param name="receivedPublicKey">Callback that can be used to store the public key details for quicker access later.</param>
        /// </summary>
        public MessageHandler(
            Func<string, Task<bool>> isTopicValid,
            Dictionary<string, string> publicKeyCache,
            Func<string, string, Task> receivedPublicKey,
            IMessageDecoder messageDecoder = null)
            : this(messageDecoder
                        ?? new AWSMessageDecoder(isTopicValid),
                   publicKeyCache,
                   receivedPublicKey)
        {
        }

        /// <summary>
        /// This constructor can be used to override the default decoding of the provided message
        /// stream, if it has been delivered by a means other than AWS.
        /// <param name="messageDecoder">Alternative message decoder implementation.</param>
        /// </summary>
        public MessageHandler(IMessageDecoder messageDecoder,
            Dictionary<string, string> publicKeyCache,
            Func<string, string, Task> receivedPublicKey)
        {
            this.messageDecoder = messageDecoder;
            this.publicKeyCache = publicKeyCache;
            this.receivedPublicKey = receivedPublicKey;
        }

        /// <summary>
        /// Handle a notification message from iVvy.
        /// <param name="messageStream">The stream that contains the message data.</param>
        /// <returns>A specific result of handling the message.</returns>
        /// </summary>
        public async Task<IHandleResult> HandleMessageAsync(Stream messageStream)
        {
            var (handleResult, ivMsg) = await messageDecoder?.DecodeMessageAsync(messageStream);

            if (ivMsg == null)
            {
                return handleResult ?? new InvalidSignatureResult();
            }

            var isSignatureValid = await ivMsg.IsSignatureValidAsync(
                publicKeyCache, receivedPublicKey
            );

            if (!isSignatureValid)
            {
                return new InvalidSignatureResult();
            }

            return new NewMessageResult(ivMsg);
        }
    }
}