using Ivvy.API.Crm;
using Newtonsoft.Json;

namespace Ivvy.Subscriptions.Messages.Crm
{
    /// <summary>
    /// A crm activity was added
    /// </summary>
    public class EventActivityAdded
    {
        /// <summary>
        /// The details of the crm activity.
        /// </summary>
        [JsonProperty("data")]
        public EventActivity EventActivity;
    }
}
