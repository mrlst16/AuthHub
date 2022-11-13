using AuthHub.Interfaces.Emails;
using AuthHub.Models.Passwords;
using AuthHub.Models.Tokens;
using Microsoft.Extensions.Configuration;

namespace AuthHub.BLL.Common.Emails
{
    public class AuthHubEmailService : IAuthHubEmailService
    {
        private readonly IEmailService _emailService;
        private readonly string _hostUrl;

        public AuthHubEmailService(
            IConfiguration configuration,
            IEmailService emailService
            )
        {
            _emailService = emailService;
            _hostUrl = configuration.GetValue<string>("AppSettings:Email:HostUrl");
        }

        public async Task SendPasswordResetEmail(string email, Guid userid, string verificationCode)
        {
            var url = $"{_hostUrl}/set_password" +
            $"?userid={userid}" +
                      $"&email={email}" +
                      $"&token={verificationCode}";
            var link = $"<a href=\"{url}\">Reset Password</a>";

            await _emailService.SendEmail(email, "AuthHub Reset Email", link);
        }

        public async Task SendUserVerificationEmail(string email, Guid userid, string verificationCode)
        {
            var url = $"{_hostUrl}/verification/user_email" +
                      $"?userid={userid}" +
                      $"&email={email}" +
                      $"&token={verificationCode}";
            var link = $"<a href=\"{url}\">Reset Password</a>";
            await _emailService.SendEmail(email, "AuthHub Verify Email", link);
        }
    }
}
