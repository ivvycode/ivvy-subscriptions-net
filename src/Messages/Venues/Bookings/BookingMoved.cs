using Ivvy.API.Venue;
using Newtonsoft.Json;

namespace Ivvy.Subscriptions.Messages.Venues.Bookings
{
    /// <summary>
    /// A booking in a venue was moved.
    /// </summary>
    public class BookingMoved
    {
        /// <summary>
        /// The details of the updated booking.
        /// </summary>
        [JsonProperty("data")]
        public Booking Booking;

        /// <summary>
        /// Any previous information of the booking that was changed.
        /// </summary>
        [JsonProperty("previousData")]
        public dynamic PreviousData;
    }
}
