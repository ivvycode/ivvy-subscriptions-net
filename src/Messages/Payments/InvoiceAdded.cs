using Ivvy.API.Invoice;
using Newtonsoft.Json;

namespace Ivvy.Subscriptions.Messages.Payments
{
    /// <summary>
    /// An invoice was added.
    /// </summary>
    public class InvoiceAdded
    {
        /// <summary>
        /// The details of the invoice.
        /// </summary>
        [JsonProperty("data")]
        public Invoice Invoice;
    }
}