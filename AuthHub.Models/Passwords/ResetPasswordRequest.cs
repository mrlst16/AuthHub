using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AuthHub.Models.Passwords
{
    public class ResetPasswordRequest : PasswordResetToken
    {
        public string NewPassword { get; set; }
    }
}
