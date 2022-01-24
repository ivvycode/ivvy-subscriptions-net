using System;
using System.IO;
using System.Threading.Tasks;
using AWSMessage = Amazon.SimpleNotificationService.Util.Message;

namespace Ivvy.Subscriptions.Handler
{
    public class AWSMessageDecoder : IMessageDecoder
    {
        /// <summary>
        /// Callback used to validate the message topic.
        /// </summary>
        private readonly Func<string, Task<bool>> isTopicValid;

        public AWSMessageDecoder(
            Func<string, Task<bool>> isTopicValid)
        {
            this.isTopicValid = isTopicValid;
        }

        public async Task<(IHandleResult, Message)> DecodeMessageAsync(Stream messageStream)
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
                return (new InvalidSignatureResult(), default);
            }

            // Validate the AWS topic.
            var isValid = await isTopicValid(awsMsg.TopicArn);
            if (!isValid)
            {
                return (new InvalidTopicResult(), default);
            }

            // If the AWS message is to confirm a subscription, then let's confirm it.
            if (awsMsg.IsSubscriptionType)
            {
                return (await ConfirmSubscription(awsMsg), default);
            }

            // If the AWS message is a notification, then extract the iVvy message.
            if (awsMsg.IsNotificationType)
            {
                return (default, Message.ParseMessage(awsMsg.MessageText));
            }

            return (new UnhandledMessageResult(), default);
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
    }
}
