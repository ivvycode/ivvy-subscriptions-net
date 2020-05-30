using Ivvy.Venue;
using Ivvy.Venue.Bookings;
using Newtonsoft.Json;
using System.Collections.Generic;

namespace Ivvy.Subscriptions.Messages.Venues.Bookings
{
    /// <summary>
    /// An accommodation group was added to a booking.
    /// </summary>
    public class AccommodationAdded
    {
        /// <summary>
        /// The status of the booking when the accommodation group was added.
        /// </summary>
        [JsonProperty("bookingStatus")]
        public Booking.StatusOptions BookingStatus { get; set; }

        /// <summary>
        /// The details of the accommodation group.
        /// </summary>
        [JsonProperty("data")]
        public Accommodation Accommodation { get; set; }
    }
}