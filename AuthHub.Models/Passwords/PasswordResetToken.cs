using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AuthHub.Models.Passwords
{
    public class PasswordResetToken
    {
        public Guid Token { get; set; }
        public string UserName { get; set; }
        public Guid OrganizationID { get; set; }
        public string AuthSettingsName { get; set; }
        public DateTime ExpirationDate { get; set; }
    }
}
