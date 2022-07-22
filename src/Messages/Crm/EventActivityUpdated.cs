using Ivvy.API.Crm;
using Newtonsoft.Json;

namespace Ivvy.Subscriptions.Messages.Crm
{
    /// <summary>
    /// A crm activity was updated
    /// </summary>
    public class EventActivityUpdated
    {
        /// <summary>
        /// The details of an updated activity.
        /// </summary>
        [JsonProperty("data")]
        public EventActivity EventActivity;

        /// <summary>
        /// Any previous information of an activity that was changed.
        /// </summary>
        [JsonProperty("previousData")]
        public dynamic PreviousData;
    }
}