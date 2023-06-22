using Newtonsoft.Json;

namespace Ivvy.Subscriptions.Messages.Venues.Bookings
{
    /// <summary>
    /// A space blockout in a venue was deleted.
    /// </summary>
    public class SpaceBlockoutDeleted
    {
        /// <summary>
        /// The unique id of the venue to which the space blockout belonged.
        /// </summary>
        [JsonProperty("venueId")]
        public int VenueId;

        /// <summary>
        /// The unique id of the space blockout that was deleted.
        /// </summary>
        [JsonProperty("spaceBlockoutId")]
        public int SpaceBlockoutId;
    }
}
