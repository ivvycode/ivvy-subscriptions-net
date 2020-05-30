using Ivvy.API.Contact;
using Newtonsoft.Json;

namespace Ivvy.Subscriptions.Messages.Contacts
{
    /// <summary>
    /// A company was updated.
    /// </summary>
    public class CompanyUpdated
    {
        /// <summary>
        /// The details of the updated company.
        /// </summary>
        [JsonProperty("data")]
        public Company Company;

        /// <summary>
        /// Any previous information of the company that was changed.
        /// </summary>
        [JsonProperty("previousData")]
        public dynamic PreviousData;
    }
}