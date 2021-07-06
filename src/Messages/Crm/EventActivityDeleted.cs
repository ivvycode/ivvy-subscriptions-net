using Newtonsoft.Json;

namespace Ivvy.Subscriptions.Messages.Crm
{
    /// <summary>
    /// A crm activity was deleted
    /// </summary>
    public class EventActivityDeleted
    {
        /// <summary>
        /// The details of a deleted activity.
        /// </summary>
        [JsonProperty("activityId")]
        public int Id;
    }
}
