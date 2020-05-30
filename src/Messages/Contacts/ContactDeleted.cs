using Newtonsoft.Json;

namespace Ivvy.Subscriptions.Messages.Contacts
{
    /// <summary>
    /// A contact was deleted.
    /// </summary>
    public class ContactDeleted
    {
        /// <summary>
        /// The unique id of the contact that was deleted.
        /// </summary>
        [JsonProperty("contactId")]
        public int ContactId
        {
            get; set;
        }
    }
}