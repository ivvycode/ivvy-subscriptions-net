using Ivvy.Venue;
using Ivvy.Venue.Bookings;
using Newtonsoft.Json;
using System.Collections.Generic;

namespace Ivvy.Subscriptions.Messages.Venues.Bookings
{
    /// <summary>
    /// A booking in a venue was updated.
    /// </summary>
    public class BookingUpdated
    {
        /// <summary>
        /// The details of the updated booking.
        /// </summary>
        [JsonProperty("data")]
        public Booking Booking
        {
            get; set;
        }

        /// <summary>
        /// Any previous information of the booking that was changed.
        /// </summary>
        [JsonProperty("previousData")]
        public dynamic PreviousData
        {
            get; set;
        }
    }
}