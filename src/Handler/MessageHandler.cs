using System;
using System.IO;
using System.Net;
using System.Collections.Generic;
using System.Threading.Tasks;
using AWSMessage = Amazon.SimpleNotificationService.Util.Message;

namespace Ivvy.Subscriptions.Handler
{
    /// <summary>
    /// This class can be used to handle subscription notification messages from iVvy.
    /// </summary>
    public class MessageHandler
    {
        /// <summary>
        /// Callback used to validate the message topic.
        /// </summary>
        private readonly Func<string, Task<bool>> isTopicValid;

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
        /// <param name="isTopicValid">Callback used to validate the message topic.</param>
        /// <param name="publicKeyCache">Keys matching the signature path will be used, avoiding a http request to fetch the public key.</param>
        /// <param name="receivedPublicKey">Callback that can be used to store the public key details for quicker access later.</param>
        /// </summary>
        public MessageHandler(
            Func<string, Task<bool>> isTopicValid,
            Dictionary<string, string> publicKeyCache,
            Func<string, string, Task> receivedPublicKey)
        {
            this.isTopicValid = isTopicValid;
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
            // Validate the AWS message signature.
            var body = "";
            using (var reader = new StreamReader(messageStream))
            {
                body = await reader.ReadToEndAsync();
            }
            var awsMsg = AWSMessage.ParseMessage(body);
            if (awsMsg == null || !awsMsg.IsMessageSignatureValid())
            {
                return new InvalidSignatureResult();
            }

            // Validate the AWS topic.
            var isValid = await isTopicValid(awsMsg.TopicArn);
            if (!isValid)
            {
                return new InvalidTopicResult();
            }

            // If the AWS message is to confirm a subscription, then let's confirm it.
            if (awsMsg.IsSubscriptionType)
            {
                return await ConfirmSubscription(awsMsg);
            }

            // If the AWS message is a notification, then extract the iVvy message.
            if (awsMsg.IsNotificationType)
            {
                return await HandleNotification(awsMsg);
            }

            return new UnhandledMessageResult();
        }

        /// <summary>
        /// Confirms a subscription to a notification topic.
        /// <param name="awsMsg">The AWS subscription type message.</param>
        /// <returns>A confirmed result on success, or an error result.</returns>
        /// </summary>
        private async Task<IHandleResult> ConfirmSubscription(AWSMessage awsMsg)
        {
            try
            {
                await Utils.MakeGetRequest(awsMsg.SubscribeURL);
                return new ConfirmedSubscriptionResult(awsMsg.TopicArn);
            }
            catch (Exception ex)
            {
                return new ErrorResult(ex);
            }
        }

        /// <summary>
        /// Handles a notification message.
        /// <param name="awsMsg">The AWS notification message, which should contain a message from iVvy.</param>
        /// <returns>A new message result, or an invalid signature result.</returns>
        /// </summary>
        private async Task<IHandleResult> HandleNotification(AWSMessage awsMsg)
        {
            // Validate the iVvy message data.
            var ivMsg = Message.ParseMessage(awsMsg.MessageText);
            if (ivMsg == null)
            {
                return new InvalidSignatureResult();
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