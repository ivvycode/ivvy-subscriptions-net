using Ivvy.API.Crm;
using Newtonsoft.Json;

namespace Ivvy.Subscriptions.Messages.CRM
{
    /// <summary>
    /// An activity was updated.
    /// </summary>
    public class CrmEventActivityUpdated
    {
        /// <summary>
        /// The details of an updated activity.
        /// </summary>
        [JsonProperty("data")]
        public EventActivity CrmEventTask;

        /// <summary>
        /// Any previous information of an activity that was changed.
        /// </summary>
        [JsonProperty("previousData")]
        public dynamic PreviousData;
    }
}
