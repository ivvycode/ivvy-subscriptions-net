using Ivvy.API.Venue;
using Ivvy.API.Venue.Bookings;
using Newtonsoft.Json;

namespace Ivvy.Subscriptions.Messages.Venues.Bookings
{
    /// <summary>
    /// A room reservation was cancelled on a booking.
    /// </summary>
    public class RoomReservationCancelled
    {
        /// <summary>
        /// The status of the booking when the room reservation was cancelled.
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