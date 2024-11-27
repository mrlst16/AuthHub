using AuthHub.Interfaces.Emails;

namespace AuthHub.BLL.Common.Emails
{
    public class BillingEmailService : IBillingEmailService
    {
        private readonly IEmailService _emailService;

        public BillingEmailService(
            IEmailService emailService
            )
        {
            _emailService = emailService;
        }

        public async Task SendPaymentReadyEmail(string toEmail, string linkToInvoice)
        {
            string body = $"<p>Your buzzauth bill is ready.</p>"
                + $"<a href=\"{linkToInvoice}\">Invoice</a>";
            await _emailService.SendEmailAsync(toEmail, "Your Buzzauth Bill is Ready", body);
        }
    }
}
