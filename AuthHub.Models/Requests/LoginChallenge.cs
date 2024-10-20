using System;

namespace AuthHub.Models.Requests
{
    public class LoginChallenge
    {
        public string UserName { get; set; }
        public string Password { get; set; }
        public int AuthSettingsId { get; set; }
    }
}
