using AuthHub.Interfaces.Emails;
using AuthHub.Models.Users;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
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
