using AuthHub.Models.Passwords;

namespace AuthHub.Interfaces.Emails
{
    public interface IAuthHubEmailLoader
    {
        Task SendPasswordResetEmail(PasswordResetToken token);
    }
}
