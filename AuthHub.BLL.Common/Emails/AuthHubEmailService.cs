using AuthHub.Interfaces.Emails;
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

        public async Task SendPasswordResetEmail(string email, int userid, string resetPasswordFormUrl, string verificationCode)
        {
            var url = $"{resetPasswordFormUrl}" +
            $"?userid={userid}" +
                      $"&verificationCode={verificationCode}";
            var link = $"<a href=\"{url}\">Reset Password</a>";

            await _emailService.SendEmailAsync(email, "Buzzauth Reset Email", link);
        }

        public async Task SendUserVerificationEmail(string email, int userid, string verificationCode)
        {
            var url = $"{_hostUrl}/api/verification/user_email" +
                      $"?userId={userid}" +
                      $"&code={verificationCode}";
            var link = $"<a href=\"{url}\">Verify Email</a>";
            await _emailService.SendEmailAsync(email, "AuthHub Verify Email", link);
        }
    }
}
