using Ivvy.Venue;
using Ivvy.Venue.Bookings;
using Newtonsoft.Json;
using System.Collections.Generic;

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
        public Booking.StatusOptions BookingStatus
        {
            get; set;
        }

        /// <summary>
        /// The details of the room reservation.
        /// </summary>
        [JsonProperty("data")]
        public RoomReservation RoomReservation
        {
            get; set;
        }
    }
}