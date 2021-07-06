using Ivvy.API.Crm;
using Newtonsoft.Json;

namespace Ivvy.Subscriptions.Messages.CRM
{
    /// <summary>
    /// An event activity was added.
    /// </summary>
    public class CrmEventActivityAdded
    {
        /// <summary>
        /// The details of the event activity.
        /// </summary>
        [JsonProperty("data")]
        public EventActivity CrmEventActivity;
    }
}
