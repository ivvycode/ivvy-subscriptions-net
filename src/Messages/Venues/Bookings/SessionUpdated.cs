using Ivvy.API.Venue.Bookings;
using Newtonsoft.Json;

namespace Ivvy.Subscriptions.Messages.Venues.Bookings
{
    /// <summary>
    /// A session on a booking was updated.
    /// </summary>
    public class SessionUpdated
    {
        /// <summary>
        /// The details of the updated session.
        /// </summary>
        [JsonProperty("data")]
        public DetailedSession Session;

        /// <summary>
        /// Any previous information of the session that was changed.
        /// </summary>
        [JsonProperty("previousData")]
        public dynamic PreviousData;
    }
}