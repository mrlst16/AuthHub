using System.Threading.Tasks;
using AuthHub.Interfaces.Billing;
using AuthHub.Models.Entities.Billing;

namespace AuthHub.BLL.Billing
{
    public class PaypalService : IPaypalService
    {
        private readonly IBillingContext _billingContext;

        public PaypalService(
            IBillingContext billingContext
            )
        {
            _billingContext = billingContext;
        }

        public async Task RecordInvoicePaymentAsync(PaypalWebhookEvent request)
        {
            var amount = double.Parse(request.Resource.TotalAmount.Value);

            await _billingContext.RecordInvoicePayment(request.Resource.Id, amount);
        }
    }
}
