using AuthHub.Interfaces.Emails;
using System.Net.Mail;
using System.Net;
using AuthHub.Models.Options;
using Microsoft.Extensions.Options;

namespace AuthHub.BLL.Common.Emails
{
    public class AWSEmailService : IEmailService
    {
        private readonly EmailServiceOptions _options;

        public AWSEmailService(
            IOptions<EmailServiceOptions> options
        )
        {
            _options = options.Value;
        }

        public async Task SendEmail(string to, string subject, string body)
        {
            // Replace sender@example.com with your "From" address. 
            // This address must be verified with Amazon SES.
            // Replace recipient@example.com with a "To" address. If your account 
            // is still in the sandbox, this address must be verified.
            // Replace smtp_username with your Amazon SES SMTP user name.
            // Replace smtp_password with your Amazon SES SMTP password.
            // (Optional) the name of a configuration set to use for this message.
            // If you comment out this line, you also need to remove or comment out
            // If you're using Amazon SES in a region other than US West (Oregon), 
            // replace email-smtp.us-west-2.amazonaws.com with the Amazon SES SMTP  
            // endpoint in the appropriate AWS Region.

            // The port you will connect to on the Amazon SES SMTP endpoint. We
            // are choosing port 587 because we will use STARTTLS to encrypt
            // the connection.
            // Create and build a new MailMessage object
            MailMessage message = new MailMessage();
            message.IsBodyHtml = true;
            message.From = new MailAddress(_options.FromEmail, _options.FromName);
            message.To.Add(new MailAddress(to));
            message.Subject = subject;
            message.Body = body;

            using (var client = new System.Net.Mail.SmtpClient(_options.HostUrl, _options.Port))
            {
                // Pass SMTP credentials
                client.Credentials = new NetworkCredential(_options.Username, _options.Password);
                // Enable SSL encryption
                client.EnableSsl = true;
                client.Send(message);
            }
        }
    }
}
