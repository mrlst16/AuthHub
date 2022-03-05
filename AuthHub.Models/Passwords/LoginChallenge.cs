using System;

namespace AuthHub.Models.Passwords
{
    public class LoginChallenge
    {
        public string UserName { get; set; }
        public string Password { get; set; }
        public Guid AuthSettingsId { get; set; }
    }
}
