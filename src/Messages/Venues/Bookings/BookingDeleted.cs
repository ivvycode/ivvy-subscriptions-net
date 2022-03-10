using Ivvy.API.Venue;
using Newtonsoft.Json;

namespace Ivvy.Subscriptions.Messages.Venues.Bookings
{
    /// <summary>
    /// A booking in a venue was deleted.
    /// </summary>
    public class BookingDeleted
    {
        /// <summary>
        /// The unique id of the venue to which the booking belonged.
        /// </summary>
        [JsonProperty("venueId")]
        public int VenueId;

        /// <summary>
        /// The unique id of the booking that was deleted.
        /// </summary>
        [JsonProperty("bookingId")]
        public int BookingId;

        /// <summary>
        /// The status of the booking when it was deleted.
        /// </summary>
        [JsonProperty("bookingStatus")]
        public Booking.StatusOptions BookingStatus;

        /// <summary>
        /// The unique ids of the group accommodation that belonged to the deleted booking.
        /// </summary>
        [JsonProperty("accommodationIds")]
        public int[] AccommodationIds;

        /// <summary>
        /// The unique ids of the room reservations that belonged to the deleted booking.
        /// </summary>
        [JsonProperty("roomReservationIds")]
        public int[] RoomReservationIds;

        /// <summary>
        /// The unique ids of the sessions that belonged to the deleted booking.
        /// </summary>
        [JsonProperty("sessionIds")]
        public int[] SessionIds;
    }
}