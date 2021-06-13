using System;

namespace AuthHub.Models.Users
{
    public class UserRequest
    {
        public Guid OrganizationID { get; set; }
        public string SettingsName { get; set; }
        public string Email { get; set; }
        public string UserName { get; set; }
        public string Password { get; set; }
    }
}
