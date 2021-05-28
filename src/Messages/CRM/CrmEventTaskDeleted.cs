using Newtonsoft.Json;

namespace Ivvy.Subscriptions.Messages.CRM
{
    /// <summary>
    /// An eventtask was deleted.
    /// </summary>
    public class CrmEventTaskDeleted
    {
        /// <summary>
        /// The unique id of the eventtask that was deleted.
        /// </summary>
        [JsonProperty("taskId")]
        public int Id;
    }
}
