using Ivvy.Venue;
using Ivvy.Venue.Bookings;
using Newtonsoft.Json;
using System.Collections.Generic;

namespace Ivvy.Subscriptions.Messages.Venues.Bookings
{
    /// <summary>
    /// A room reservation was added to a booking.
    /// </summary>
    public class RoomReservationAdded
    {
        /// <summary>
        /// The status of the booking when the room reservation was added.
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