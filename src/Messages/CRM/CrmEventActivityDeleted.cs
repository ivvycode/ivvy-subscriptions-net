using Ivvy.API.Crm;
using Newtonsoft.Json;

namespace Ivvy.Subscriptions.Messages.CRM
{
    /// <summary>
    /// An event activity was deleted.
    /// </summary>
    public class CrmEventActivityDeleted
    {
        /// <summary>
        /// The details of a deleted activity.
        /// </summary>
        [JsonProperty("activityId")]
        public int Id;
    }
}
