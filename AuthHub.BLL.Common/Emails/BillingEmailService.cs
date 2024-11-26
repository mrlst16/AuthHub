using AuthHub.Interfaces.Emails;

namespace AuthHub.BLL.Common.Emails
{
    public class BillingEmailService : IBillingEmailService
    {
        public Task SendPaymentReadyEmail(string toEmail, string linkToInvoice)
        {
            throw new NotImplementedException();
        }
    }
}
