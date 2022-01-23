using Ivvy.API.Venue.Bookings;
using Newtonsoft.Json;

namespace Ivvy.Subscriptions.Messages.Venues.Bookings
{
    /// <summary>
    /// A session was added to a booking.
    /// </summary>
    public class SessionAdded
    {
        /// <summary>
        /// The details of the session.
        /// </summary>
        [JsonProperty("data")]
        public DetailedSession Session;
    }
}