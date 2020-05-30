using Ivvy.API.Venue;
using Newtonsoft.Json;

namespace Ivvy.Subscriptions.Messages.Venues.Bookings
{
    /// <summary>
    /// A room reservation on a booking was deleted
    /// </summary>
    public class RoomReservationDeleted
    {
        /// <summary>
        /// The unique id of the venue to which the booking belongs.
        /// </summary>
        [JsonProperty("venueId")]
        public int VenueId;

        /// <summary>
        /// The status of the booking when the room reservation was deleted.
        /// </summary>
        [JsonProperty("bookingStatus")]
        public Booking.StatusOptions BookingStatus;

        /// <summary>
        /// The unique id of the booking to which the room reservation belonged.
        /// </summary>
        [JsonProperty("bookingId")]
        public int BookingId;

        /// <summary>
        /// The unique id of the room reservation that was deleted.
        /// </summary>
        [JsonProperty("reservationId")]
        public int ReservationId;

        /// <summary>
        /// The unique ids of the individual rooms that belonged to the deleted room reservation.
        /// </summary>
        [JsonProperty("roomIds")]
        public int[] RoomIds;
    }
}