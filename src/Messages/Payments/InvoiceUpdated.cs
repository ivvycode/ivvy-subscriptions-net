using Ivvy.API.Invoice;
using Newtonsoft.Json;

namespace Ivvy.Subscriptions.Messages.Payments
{
    /// <summary>
    /// An invoice was updated.
    /// </summary>
    public class InvoiceUpdated
    {
        /// <summary>
        /// The details of the updated invoice.
        /// </summary>
        [JsonProperty("data")]
        public Invoice Invoice;

        /// <summary>
        /// Any previous information of the invoice that was changed.
        /// </summary>
        [JsonProperty("previousData")]
        public dynamic PreviousData;
    }
}
