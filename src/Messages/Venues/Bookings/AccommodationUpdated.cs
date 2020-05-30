using Ivvy.API.Venue;
using Ivvy.API.Venue.Bookings;
using Newtonsoft.Json;

namespace Ivvy.Subscriptions.Messages.Venues.Bookings
{
    /// <summary>
    /// An accommodation group on a booking was updated.
    /// </summary>
    public class AccommodationUpdated
    {
        /// <summary>
        /// The status of the booking when the accommodation group was updated.
        /// </summary>
        [JsonProperty("bookingStatus")]
        public Booking.StatusOptions BookingStatus;

        /// <summary>
        /// The details of the updated accommodation group.
        /// </summary>
        [JsonProperty("data")]
        public Accommodation Accommodation;

        /// <summary>
        /// Any previous information of the accommodation group that was changed.
        /// </summary>
        [JsonProperty("previousData")]
        public dynamic PreviousData;
    }
}