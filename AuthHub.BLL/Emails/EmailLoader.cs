using AuthHub.Interfaces.Emails;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Mail;
using System.Text;
using System.Threading.Tasks;

namespace AuthHub.BLL.Emails
{
    public class EmailLoader : IEmailLoader
    {
        public async Task SendEmail(string to, string from, string subject, string body)
        {
            using(var client = new SmtpClient())
            {

            }
        }
    }
}
