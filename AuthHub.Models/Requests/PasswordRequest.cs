using System;

namespace AuthHub.Models.Requests
{
    public class PasswordRequest
    {
        public string UserName { get; set; }
        public string Password { get; set; }
        public int OrganizationID { get; set; }
        public int AuthSettingsId { get; set; }
        public string SettingsName { get; set; }
    }
}