using System;

namespace AuthHub.Models.Passwords
{
    public class PasswordResetToken
    {
        public Guid Token { get; set; }
        public string UserName { get; set; }
        public string Email { get; set; }
        public Guid OrganizationID { get; set; }
        public string AuthSettingsName { get; set; }
        public DateTime ExpirationDate { get; set; }
    }
}
