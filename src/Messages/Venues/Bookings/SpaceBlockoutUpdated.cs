using Ivvy.API.Venue.Bookings;
using Newtonsoft.Json;

namespace Ivvy.Subscriptions.Messages.Venues.Bookings
{
    /// <summary>
    /// A space blockout in a venue was updated.
    /// </summary>
    public class SpaceBlockoutUpdated
    {
        /// <summary>
        /// The details of the added space blockout.
        /// </summary>
        [JsonProperty("data")]
        public SpaceBlockout SpaceBlockout;

        /// <summary>
        /// Any previous information of the session that was changed.
        /// </summary>
        [JsonProperty("previousData")]
        public dynamic PreviousData;
    }
}
