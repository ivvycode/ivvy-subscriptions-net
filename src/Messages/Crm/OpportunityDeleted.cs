using Newtonsoft.Json;

namespace Ivvy.Subscriptions.Messages.Crm
{
    /// <summary>
    /// An opportunity was deleted
    /// </summary>
    public class OpportunityDeleted
    {
        /// <summary>
        /// The unique id of the opportunity that was deleted.
        /// </summary>
        [JsonProperty("opportunityId")]
        public int Id;

        /// <summary>
        /// The unique id of the venue the opportunity belongs to.
        /// </summary>
        [JsonProperty("venueId")]
        public int? VenueId;
    }
}