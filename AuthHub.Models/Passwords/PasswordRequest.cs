using System;

namespace AuthHub.Models.Passwords
{
    public class PasswordRequest
    {
        public string UserName { get; set; }
        public string Password { get; set; }
        public Guid OrganizationID { get; set; }
        public string SettingsName { get; set; }
    }
}
