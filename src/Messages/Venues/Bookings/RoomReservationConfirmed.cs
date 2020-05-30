using Ivvy.API.Venue;
using Ivvy.API.Venue.Bookings;
using Newtonsoft.Json;

namespace Ivvy.Subscriptions.Messages.Venues.Bookings
{
    /// <summary>
    /// A room reservation was confirmed on a booking.
    /// </summary>
    public class RoomReservationConfirmed
    {
        /// <summary>
        /// The status of the booking when the room reservation was confirmed.
        /// </summary>
        [JsonProperty("bookingStatus")]
        public Booking.StatusOptions BookingStatus;

        /// <summary>
        /// The details of the room reservation.
        /// </summary>
        [JsonProperty("data")]
        public RoomReservation RoomReservation;
    }
}