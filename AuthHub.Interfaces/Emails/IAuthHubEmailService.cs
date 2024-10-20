using System;
namespace AuthHub.Interfaces.Emails
{
    public interface IAuthHubEmailService
    {
        Task SendPasswordResetEmail(string email, int userid, string resetPasswordFormUrl, string verificationCode);
        Task SendUserVerificationEmail(string email, int userid, string verificationCode);
    }
}
