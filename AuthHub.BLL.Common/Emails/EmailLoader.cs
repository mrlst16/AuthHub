using AuthHub.Interfaces.Emails;
using System.Net.Mail;

namespace AuthHub.BLL.Common.Emails
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
