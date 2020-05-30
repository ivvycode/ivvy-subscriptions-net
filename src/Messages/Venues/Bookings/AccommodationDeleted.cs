using Ivvy.API.Venue;
using Newtonsoft.Json;

namespace Ivvy.Subscriptions.Messages.Venues.Bookings
{
    /// <summary>
    /// An accommodation group on a booking was deleted
    /// </summary>
    public class AccommodationDeleted
    {
        /// <summary>
        /// The unique id of the venue to which the booking belongs.
        /// </summary>
        [JsonProperty("venueId")]
        public int VenueId;

        /// <summary>
        /// The status of the booking when the accommodation group was deleted.
        /// </summary>
        [JsonProperty("bookingStatus")]
        public Booking.StatusOptions BookingStatus;

        /// <summary>
        /// The unique id of the booking to which the accommodation belonged.
        /// </summary>
        [JsonProperty("bookingId")]
        public int BookingId;

        /// <summary>
        /// The unique id of the accommodation group that was deleted.
        /// </summary>
        [JsonProperty("accommodationId")]
        public int AccommodationId;
    }
}