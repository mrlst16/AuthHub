using AuthHub.Interfaces.Emails;
using AuthHub.Models.Passwords;
using Microsoft.Extensions.Configuration;
using System.Net;
using System.Net.Mail;
using System.Threading.Tasks;

namespace AuthHub.BLL.Emails
{
    public class AuthHubEmailLoader : IAuthHubEmailLoader
    {
        private readonly string _serverAddress;
        private readonly string _fromEmail;
        private readonly string _password;
        private readonly int _port;
        private readonly string _hostUrl;

        public AuthHubEmailLoader(
            IConfiguration configuration
            )
        {
            _serverAddress = configuration.GetValue<string>("AppSettings:Email:ServerAddress");
            _fromEmail = configuration.GetValue<string>("AppSettings:Email:From");
            _password = configuration.GetValue<string>("AppSettings:Email:Password");
            _port = configuration.GetValue<int>("AppSettings:Email:Port");
            _hostUrl = configuration.GetValue<string>("AppSettings:HostUrl");
        }

        public async Task SendPasswordResetEmail(PasswordResetToken token)
        {
            using (SmtpClient client = new SmtpClient(_serverAddress, _port)
            {
                EnableSsl = true,
                Credentials = new NetworkCredential(_fromEmail, _password)
            })
            {
                var url = $"{_hostUrl}/api/reset_password" +
                    $"?username={token.UserName}" +
                    $"&email={token.Email}" +
                    $"&token={token.Token}" +
                    $"&organizationId={token.OrganizationID}" +
                    $"&authSettingsName={token.AuthSettingsName}";
                var link = $"<a href=\"{url}\">Reset Password</a>";
                client.Send(_fromEmail, token.Email, "Audder: Reset Password", link);
            }
        }
    }
}
