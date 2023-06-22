using Ivvy.API.Venue.Bookings;
using Newtonsoft.Json;

namespace Ivvy.Subscriptions.Messages.Venues.Bookings
{
    /// <summary>
    /// A blockout was added to a venue function space.
    /// </summary>
    public class SpaceBlockoutAdded
    {
        /// <summary>
        /// The details of the added space blockout.
        /// </summary>
        [JsonProperty("data")]
        public SpaceBlockout SpaceBlockout;
    }
}
