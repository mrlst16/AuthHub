using AuthHub.Interfaces.Emails;
using AuthHub.Models.Options;
using Microsoft.Extensions.Options;
using SendGrid;
using SendGrid.Helpers.Mail;

namespace AuthHub.BLL.Common.Emails
{
    public class SendGridEmailService : IEmailService
    {
        private readonly EmailServiceOptions _options;

        public SendGridEmailService(
            IOptions<EmailServiceOptions> options
        )
        {
            _options = options.Value;
        }

        public async Task SendEmail(string to, string subject, string body)
        {
            var client = new SendGridClient(_options.ApiKey);
            var from = new EmailAddress(_options.FromEmail);
            var toAddress = new EmailAddress(to);
            var msg = MailHelper.CreateSingleEmail(from, toAddress, subject, body, body);
            var response = await client.SendEmailAsync(msg);
        }
    }
}
