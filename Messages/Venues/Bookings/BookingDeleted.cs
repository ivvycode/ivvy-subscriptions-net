using Ivvy.Venue;
using Ivvy.Venue.Bookings;
using Newtonsoft.Json;
using System.Collections.Generic;

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
        public int VenueId { get; set; }

        /// <summary>
        /// The unique id of the booking that was deleted.
        /// </summary>
        [JsonProperty("bookingId")]
        public int BookingId { get; set; }
    }
}