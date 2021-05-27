using Ivvy.API.Crm;
using Newtonsoft.Json;

namespace Ivvy.Subscriptions.Messages.CRM
{
    /// <summary>
    /// A task was updated.
    /// </summary>
    public class CrmEventTaskUpdated
    {
        /// <summary>
        /// The details of the updated task.
        /// </summary>
        [JsonProperty("data")]
        public EventTask CrmEventTask;

        /// <summary>
        /// Any previous information of the task that was changed.
        /// </summary>
        [JsonProperty("previousData")]
        public dynamic PreviousData;
    }
}
