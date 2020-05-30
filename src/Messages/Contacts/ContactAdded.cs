using Newtonsoft.Json;

namespace Ivvy.Subscriptions.Messages.Contacts
{
    /// <summary>
    /// A contact was added.
    /// </summary>
    public class ContactAdded
    {
        /// <summary>
        /// The details of the contact.
        /// </summary>
        [JsonProperty("data")]
        public Contact.Contact Contact
        {
            get; set;
        }
    }
}