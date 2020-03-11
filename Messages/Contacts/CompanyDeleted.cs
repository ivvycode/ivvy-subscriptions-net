using Newtonsoft.Json;

namespace Ivvy.Subscriptions.Messages.Contacts
{
    /// <summary>
    /// Existing Company / Account was deleted.
    /// </summary>
    public class CompanyDeleted
    {
        /// <summary>
        /// The unique id of the Company that existed earlier.
        /// </summary>
        [JsonProperty("companyId")]
        public int CompanyId { get; set; }

        /// <summary>
        /// The business name of the Company that existed earlier.
        /// </summary>
        [JsonProperty("businessName")]
        public string BusinessName { get; set; }
    }
}