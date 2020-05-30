using Ivvy.Venue;
using Ivvy.Venue.Bookings;
using Newtonsoft.Json;
using System.Collections.Generic;

namespace Ivvy.Subscriptions.Messages.Venues.Bookings
{
    /// <summary>
    /// A room reservation was added to a booking.
    /// </summary>
    public class RoomReservationUpdated
    {
        /// <summary>
        /// The status of the booking when the room reservation was updated.
        /// </summary>
        [JsonProperty("bookingStatus")]
        public Booking.StatusOptions BookingStatus { get; set; }

        /// <summary>
        /// The details of the room reservation.
        /// </summary>
        [JsonProperty("data")]
        public RoomReservation RoomReservation { get; set; }

        /// <summary>
        /// Any previous information of the room reservation that was changed.
        /// </summary>
        [JsonProperty("previousData")]
        public dynamic PreviousData { get; set; }

        /// <summary>
        /// Any new information that was added to the room reservation when changed.
        /// </summary>
        [JsonProperty("newestData")]
        public dynamic NewestData { get; set; }
    }
}