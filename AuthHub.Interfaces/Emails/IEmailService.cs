using AuthHub.Models.Users;
using System.Threading.Tasks;

namespace AuthHub.Interfaces.Emails
{
    public interface IEmailService
    {
        Task SendResetPasswordEmail(UserPointer userPointer);
    }
}