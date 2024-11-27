using AuthHub.Interfaces.Emails;
using AuthHub.Models.Options;
using Microsoft.Extensions.Options;
using System.Net;
using System.Net.Mail;

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

        public async Task SendEmailAsync(string to, string subject, string body)
        {
            using SmtpClient client = new(_options.Server, _options.Port)
            {
                EnableSsl = true,
                Credentials = new NetworkCredential(_options.Username, _options.Password)
            };

            var message = new MailMessage(_options.FromEmail, to, subject, body);

            await client.SendMailAsync(message);
        }
    }
}
