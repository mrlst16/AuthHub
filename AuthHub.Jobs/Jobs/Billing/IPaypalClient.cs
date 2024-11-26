using AuthHub.Jobs.Models.Billing.Paypal;

namespace AuthHub.Jobs.Jobs.Billing
{
    public interface IPaypalClient
    {
        Task<PaypalAuthorizationResponse> GetAuthorizationAsync();
        Task<CreateDraftResponse> CreateDraftInvoiceAsync(PaypalInvoice paypalInvoice);
        Task<SendInvoiceResponse> SendInvoiceAsync(string invoiceId);
    }
}
