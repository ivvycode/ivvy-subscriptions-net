using Newtonsoft.Json;

namespace Ivvy.Subscriptions.Messages.Contacts
{
    /// <summary>
    /// A new Company / Account was added.
    /// </summary>
    public class CompanyAdded
    {
        /// <summary>
        /// The details of the Company object.
        /// </summary>
        [JsonProperty("data")]
        public Contact.Company Company { get; set; }
    }
}