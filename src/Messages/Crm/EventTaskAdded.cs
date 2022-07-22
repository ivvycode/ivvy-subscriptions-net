using Ivvy.API.Crm;
using Newtonsoft.Json;

namespace Ivvy.Subscriptions.Messages.Crm
{
    /// <summary>
    /// A crm task was added
    /// </summary>
    public class EventTaskAdded
    {
        /// <summary>
        /// The details of the crm task.
        /// </summary>
        [JsonProperty("data")]
        public EventTask EventTask;
    }
}