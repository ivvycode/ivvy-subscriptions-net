using Ivvy.API.Crm;
using Newtonsoft.Json;

namespace Ivvy.Subscriptions.Messages.Crm
{
    /// <summary>
    /// An opportunity was added
    /// </summary>
    public class OpportunityAdded
    {
        /// <summary>
        /// The details of the opportunity.
        /// </summary>
        [JsonProperty("data")]
        public Opportunity Opportunity;
    }
}
