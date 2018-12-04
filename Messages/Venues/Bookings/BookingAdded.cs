using Ivvy.Venue;
using Ivvy.Venue.Bookings;
using Newtonsoft.Json;
using System.Collections.Generic;

namespace Ivvy.Subscriptions.Messages.Venues.Bookings
{
    /// <summary>
    /// A booking was added to a venue.
    /// </summary>
    public class BookingAdded
    {
        /// <summary>
        /// The details of the booking.
        /// </summary>
        [JsonProperty("data")]
        public Booking Booking { get; set; }
    }
}