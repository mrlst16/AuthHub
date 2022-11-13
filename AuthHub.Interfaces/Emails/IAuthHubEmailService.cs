using System;
namespace AuthHub.Interfaces.Emails
{
    public interface IAuthHubEmailService
    {
        Task SendPasswordResetEmail(string email, Guid userid, string verificationCode);
        Task SendUserVerificationEmail(string email, Guid userid, string verificationCode);
    }
}
