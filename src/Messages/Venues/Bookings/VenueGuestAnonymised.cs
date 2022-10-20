using Newtonsoft.Json;

namespace Ivvy.Subscriptions.Messages.Venues.Bookings
{
    /// <summary>
    /// A guest was anonymised
    /// </summary>
    public class VenueGuestAnonymised
    {
        /// <summary>
        /// The unique id of the guest that was anonymised.
        /// </summary>
        [JsonProperty("guestContactId")]
        public int GuestContactId
        {
            get; set;
        }
    }
}