using Newtonsoft.Json;

namespace Ivvy.Subscriptions.Messages.Contacts
{
    /// <summary>
    /// A contact was updated.
    /// </summary>
    public class ContactUpdated
    {
        /// <summary>
        /// The details of the updated contact.
        /// </summary>
        [JsonProperty("data")]
        public Contact.Contact Contact
        {
            get; set;
        }

        /// <summary>
        /// Any previous information of the contact that was changed.
        /// </summary>
        [JsonProperty("previousData")]
        public dynamic PreviousData
        {
            get; set;
        }
    }
}