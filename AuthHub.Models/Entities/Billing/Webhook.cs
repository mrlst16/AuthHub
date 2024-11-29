using System.Collections.Generic;
using System.Text.Json.Serialization;

namespace AuthHub.Models.Entities.Billing
{
    public class Amount
    {
        public string Value { get; set; }
        public string Currency { get; set; }
        public AmountDetails Details { get; set; }
    }

    public class AmountDetails
    {
        public string Subtotal { get; set; }
    }

    public class Link
    {
        public string Href { get; set; }
        public string Rel { get; set; }
        public string Method { get; set; }
    }

    public class Resource
    {
        public string Id { get; set; }
        public string CreateTime { get; set; }
        public string UpdateTime { get; set; }
        public string State { get; set; }
        [JsonPropertyName("total_amount")]
        public Amount TotalAmount { get; set; }
        public string ParentPayment { get; set; }
        public string ValidUntil { get; set; }
        public List<Link> Links { get; set; }
    }

    public class PaypalWebhookEvent
    {
        public string Id { get; set; }
        public string CreateTime { get; set; }
        public string ResourceType { get; set; }
        public string EventVersion { get; set; }
        public string EventType { get; set; }
        public string Summary { get; set; }
        public Resource Resource { get; set; }
        public List<Link> Links { get; set; }
    }
}
