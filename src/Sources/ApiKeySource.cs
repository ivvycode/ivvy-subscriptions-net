using Newtonsoft.Json;

namespace Ivvy.Subscriptions.Sources
{
    /// <summary>
    /// The source of the message was an API request.
    /// </summary>
    public class ApiKeySource
    {
        /// <summary>
        /// The key that was used by the API request that sourced the message.
        /// </summary>
        [JsonProperty("key")]
        public string Key { get; set; }
    }
}