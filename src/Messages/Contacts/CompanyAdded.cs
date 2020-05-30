using Ivvy.API.Contact;
using Newtonsoft.Json;

namespace Ivvy.Subscriptions.Messages.Contacts
{
    /// <summary>
    /// A company was added.
    /// </summary>
    public class CompanyAdded
    {
        /// <summary>
        /// The details of the company.
        /// </summary>
        [JsonProperty("data")]
        public Company Company;
    }
}