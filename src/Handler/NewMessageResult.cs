namespace Ivvy.Subscriptions.Handler
{
    /// <summary>
    /// A new notification message has been received.
    /// </summary>
    public class NewMessageResult : IHandleResult
    {
        /// <summary>
        /// The actual message.
        /// </summary>
        public readonly Message Message;

        /// <summary>
        /// A new notification message has been received.
        /// <param name="msg">The actual message.</param>
        /// </summary>
        public NewMessageResult(Message msg)
        {
            Message = msg;
        }
    }
}