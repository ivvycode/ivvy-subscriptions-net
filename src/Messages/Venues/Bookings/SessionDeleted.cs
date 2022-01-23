using Newtonsoft.Json;

namespace Ivvy.Subscriptions.Messages.Venues.Bookings
{
    /// <summary>
    /// A session on a booking was deleted
    /// </summary>
    public class SessionDeleted
    {
        /// <summary>
        /// The unique id of the venue to which the booking belongs.
        /// </summary>
        [JsonProperty("venueId")]
        public int VenueId;

        /// <summary>
        /// The unique id of the booking to which the session belonged.
        /// </summary>
        [JsonProperty("bookingId")]
        public int BookingId;

        /// <summary>
        /// The unique id of the session that was deleted.
        /// </summary>
        [JsonProperty("sessionId")]
        public int SessionId;
    }
}