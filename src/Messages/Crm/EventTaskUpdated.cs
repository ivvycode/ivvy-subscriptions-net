using Ivvy.API.Crm;
using Newtonsoft.Json;

namespace Ivvy.Subscriptions.Messages.Crm
{
    /// <summary>
    /// A crm task was updated
    /// </summary>
    public class EventTaskUpdated
    {
        /// <summary>
        /// The details of the updated task.
        /// </summary>
        [JsonProperty("data")]
        public EventTask EventTask;

        /// <summary>
        /// Any previous information of the task that was changed.
        /// </summary>
        [JsonProperty("previousData")]
        public dynamic PreviousData;
    }
}