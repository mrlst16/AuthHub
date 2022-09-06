using AuthHub.Models.Users;

namespace AuthHub.Interfaces.Emails
{
    public interface IEmailService
    {
        Task SendResetPasswordEmail(UserPointer userPointer);
    }
}