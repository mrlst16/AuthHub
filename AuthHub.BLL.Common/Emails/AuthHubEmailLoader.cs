using AuthHub.Interfaces.Emails;
using AuthHub.Models.Passwords;
using CommonCore.Interfaces.Helpers;
using Microsoft.Extensions.Configuration;
using System.Net;
using System.Net.Mail;

namespace AuthHub.BLL.Common.Emails
{
    public class AuthHubEmailLoader : IAuthHubEmailLoader
    {
        private readonly string _serverAddress;
        private readonly string _fromEmail;
        private readonly string _password;
        private readonly int _port;
        private readonly string _hostUrl;
        private readonly IApplicationConsistency _applicationHelper;

        public AuthHubEmailLoader(
            IConfiguration configuration,
            IApplicationConsistency applicationHelper
            )
        {
            _serverAddress = configuration.GetValue<string>("AppSettings:Email:ServerAddress");
            _fromEmail = configuration.GetValue<string>("AppSettings:Email:From");
            _password = configuration.GetValue<string>("AppSettings:Email:Password");
            _port = configuration.GetValue<int>("AppSettings:Email:Port");
            _hostUrl = configuration.GetValue<string>("AppSettings:Email:HostUrl");
            _applicationHelper = applicationHelper;
        }

        public async Task SendPasswordResetEmail(PasswordResetToken token)
        {
            using (SmtpClient client = new SmtpClient(_serverAddress, _port)
            {
                EnableSsl = true,
                Credentials = new NetworkCredential(_fromEmail, _password)
            })
            {
                var url = $"{_hostUrl}/set_password" +
                    $"?userid={token.UserId}" +
                    $"&email={token.Email}" +
                    $"&token={token.Token}";
                var link = $"<a href=\"{url}\">Reset Password</a>";

                var message = new MailMessage(_fromEmail, token.Email)
                {
                    Subject = "Audder: Reset Password",
                    Body = link
                };

                CancellationTokenSource cancellationTokenSource = new CancellationTokenSource();

                await client.SendMailAsync(message, cancellationTokenSource.Token);
            }
        }
    }
}
