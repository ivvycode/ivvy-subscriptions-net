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

        /// <summary>
        /// The status of the booking when it was deleted.
        /// </summary>
        [JsonProperty("bookingStatus")]
        public Booking.StatusOptions BookingStatus { get; set; }

        /// <summary>
        /// The unique ids of the group accommodation that belonged to the deleted booking.
        /// </summary>
        [JsonProperty("accommodationIds")]
        public int[] AccommodationIds { get; set; }

        /// <summary>
        /// The unique ids of the room reservations that belonged to the deleted booking.
        /// </summary>
        [JsonProperty("roomReservationIds")]
        public int[] RoomReservationIds { get; set; }
    }
}