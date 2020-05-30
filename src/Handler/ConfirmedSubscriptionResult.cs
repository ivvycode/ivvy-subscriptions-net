namespace Ivvy.Subscriptions.Handler
{
    /// <summary>
    /// A subscription to a notification topic has just been confirmed.
    /// </summary>
    public class ConfirmedSubscriptionResult : IHandleResult
    {
        public readonly string TopicArn = "";

        public ConfirmedSubscriptionResult(string topicArn)
        {
            TopicArn = topicArn;
        }
    }
}