using System;

namespace Ivvy.Subscriptions.Handler
{
    /// <summary>
    /// An error occurred whilst handling a notification message.
    /// </summary>
    public class ErrorResult : IHandleResult
    {
        /// <summary>
        /// The actual error.
        /// </summary>
        public readonly Exception Error;

        /// <summary>
        /// An error occurred whilst handling a notification message.
        /// <param name="ex">The actual error.</param>
        /// </summary>
        public ErrorResult(Exception ex)
        {
            Error = ex;
        }
    }
}