using AuthHub.Models.Entities.Billing;

namespace AuthHub.Interfaces.Billing
{
    public interface IPaypalService
    {
        Task RecordInvoicePaymentAsync(PaypalWebhookEvent request);
    }
}
