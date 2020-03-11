using Newtonsoft.Json;

namespace Ivvy.Subscriptions.Messages.Contacts
{
    /// <summary>
    /// Existing contact was updated.
    /// </summary>
    public class ContactUpdated
    {
        /// <summary>
        /// The details of the updated Contact
        /// </summary>
        [JsonProperty("data")]
        public Contact.Contact Contact { get; set; }

        /// <summary>
        /// Any previous information of the existing contact that was changed
        /// </summary>
        [JsonProperty("previousData")]
        public dynamic PreviousData { get; set; }
    }
}