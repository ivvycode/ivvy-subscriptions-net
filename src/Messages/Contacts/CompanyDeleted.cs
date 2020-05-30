using Newtonsoft.Json;

namespace Ivvy.Subscriptions.Messages.Contacts
{
    /// <summary>
    /// A company was deleted.
    /// </summary>
    public class CompanyDeleted
    {
        /// <summary>
        /// The unique id of the company that was deleted.
        /// </summary>
        [JsonProperty("companyId")]
        public int CompanyId
        {
            get; set;
        }
    }
}