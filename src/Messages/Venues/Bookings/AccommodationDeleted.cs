using Ivvy.Venue;
using Ivvy.Venue.Bookings;
using Newtonsoft.Json;
using System.Collections.Generic;

namespace Ivvy.Subscriptions.Messages.Venues.Bookings
{
    /// <summary>
    /// An accommodation group on a booking was deleted
    /// </summary>
    public class AccommodationDeleted
    {
        /// <summary>
        /// The unique id of the venue to which the booking belongs.
        /// </summary>
        [JsonProperty("venueId")]
        public int VenueId
        {
            get; set;
        }

        /// <summary>
        /// The status of the booking when the accommodation group was deleted.
        /// </summary>
        [JsonProperty("bookingStatus")]
        public Booking.StatusOptions BookingStatus
        {
            get; set;
        }

        /// <summary>
        /// The unique id of the booking to which the accommodation belonged.
        /// </summary>
        [JsonProperty("bookingId")]
        public int BookingId
        {
            get; set;
        }

        /// <summary>
        /// The unique id of the accommodation group that was deleted.
        /// </summary>
        [JsonProperty("accommodationId")]
        public int AccommodationId
        {
            get; set;
        }
    }
}