using AuthHub.Models.Passwords;
using System.Threading.Tasks;

namespace AuthHub.Interfaces.Emails
{
    public interface IAuthHubEmailLoader
    {
        Task SendPasswordResetEmail(PasswordResetToken token);
    }
}
