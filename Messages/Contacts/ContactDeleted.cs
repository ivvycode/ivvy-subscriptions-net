using Newtonsoft.Json;

namespace Ivvy.Subscriptions.Messages.Contacts
{
    /// <summary>
    /// Existing contact was deleted.
    /// </summary>
    public class ContactDeleted
    {
        /// <summary>
        /// The unique id of the Contact that is deleted.
        /// </summary>
        [JsonProperty("contactId")]
        public int ContactId { get; set; }

        /// <summary>
        /// First name of the contact that is deleted.
        /// </summary>
        [JsonProperty("firstName")]
        public string FirstName { get; set; }

        /// <summary>
        /// Last name of the contact that is deleted
        /// </summary>
        [JsonProperty("lastName")]
        public string LastName { get; set; }
    }
}