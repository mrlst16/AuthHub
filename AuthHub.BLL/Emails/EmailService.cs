using AuthHub.Interfaces.Emails;
using AuthHub.Models.Users;
using System.Threading.Tasks;

namespace AuthHub.BLL.Emails
{
    public class EmailService : IEmailService
    {
        public async Task SendResetPasswordEmail(UserPointer userPointer)
        {

        }
    }
}
