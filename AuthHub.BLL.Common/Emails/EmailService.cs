using AuthHub.Interfaces.Emails;
using System.Net;
using System.Net.Mail;
using AuthHub.Models.Options;
using Microsoft.Extensions.Options;

namespace AuthHub.BLL.Common.Emails
{
    public class EmailService : IEmailService
    {
        private readonly EmailServiceOptions _options;

        public EmailService(
            IOptions<EmailServiceOptions> options
            )
        {
            _options = options.Value;
        }

        public async Task SendEmail(string to, string subject, string body)
        {
            using SmtpClient client = new SmtpClient(_options.ServerAddress, _options.Port)
            {
                EnableSsl = true,
                Credentials = new NetworkCredential(_options.FromEmail, _options.Password)
            };

            var message = new MailMessage(_options.FromEmail, to, subject, body);

            await client.SendMailAsync(message);
        }
    }
}
