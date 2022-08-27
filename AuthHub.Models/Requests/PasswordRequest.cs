using System;

namespace AuthHub.Models.Requests
{
    public class PasswordRequest
    {
        public string UserName { get; set; }
        public string Password { get; set; }
        public Guid OrganizationID { get; set; }
        public Guid AuthSettingsId { get; set; }
        public string SettingsName { get; set; }
    }
}