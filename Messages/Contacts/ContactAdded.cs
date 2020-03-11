using Newtonsoft.Json;

namespace Ivvy.Subscriptions.Messages.Contacts
{
    /// <summary>
    /// A new contact was added.
    /// </summary>
    public class ContactAdded
    {
        /// <summary>
        /// The details of the Contact object.
        /// </summary>
        [JsonProperty("data")]
        public Contact.Contact Contact { get; set; }
    }
}