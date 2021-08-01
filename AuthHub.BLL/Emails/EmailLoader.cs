using AuthHub.Interfaces.Emails;
using System.Net.Mail;
using System.Threading.Tasks;

namespace AuthHub.BLL.Emails
{
    public class EmailLoader : IEmailLoader
    {
        public async Task SendEmail(string to, string from, string subject, string body)
        {
            using (var client = new SmtpClient())
            {

            }
        }
    }
}
