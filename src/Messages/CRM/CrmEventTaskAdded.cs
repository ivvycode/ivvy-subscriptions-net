using Ivvy.API.Crm;
using Newtonsoft.Json;

namespace Ivvy.Subscriptions.Messages.CRM
{
    /// <summary>
    /// An eventtask was added.
    /// </summary>
    public class CrmEventTaskAdded
    {
        /// <summary>
        /// The details of the event task.
        /// </summary>
        [JsonProperty("data")]
        public EventTask CrmEventTask;
    }
}
