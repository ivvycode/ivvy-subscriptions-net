using Ivvy.API.Crm;
using Newtonsoft.Json;

namespace Ivvy.Subscriptions.Messages.Crm
{
    /// <summary>
    /// An opportunity was updated
    /// </summary>
    public class OpportunityUpdated
    {
        /// <summary>
        /// The details of the updated opportunity.
        /// </summary>
        [JsonProperty("data")]
        public Opportunity Opportunity;

        /// <summary>
        /// Any previous information of the opportunity that was changed.
        /// </summary>
        [JsonProperty("previousData")]
        public dynamic PreviousData;
    }
}
