using Newtonsoft.Json;

namespace Ivvy.Subscriptions.Messages.Contacts
{
    /// <summary>
    /// Existing Company / Account was updated.
    /// </summary>
    public class CompanyUpdated
    {
        /// <summary>
        /// The details of the updated Company.
        /// </summary>
        [JsonProperty("data")]
        public Contact.Company Company { get; set; }

        /// <summary>
        /// Any previous information of the Company that was changed.
        /// </summary>
        [JsonProperty("previousData")]
        public dynamic PreviousData { get; set; }
    }
}