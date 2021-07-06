using Newtonsoft.Json;

namespace Ivvy.Subscriptions.Messages.Crm
{
    /// <summary>
    /// A crm task was deleted
    /// </summary>
    public class EventTaskDeleted
    {
        /// <summary>
        /// The unique id of the eventtask that was deleted.
        /// </summary>
        [JsonProperty("taskId")]
        public int Id;
    }
}
