using AuthHub.Models.Users;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AuthHub.Interfaces.Emails
{
    public interface IEmailService
    {
        Task SendResetPasswordEmail(UserPointer userPointer);
    }
}