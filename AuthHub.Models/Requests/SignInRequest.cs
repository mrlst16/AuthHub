using System;

namespace AuthHub.Models.Requests
{
    public class SignInRequest
    {
        public int AuthSettingsId { get; set; }
        public string UserName { get; set; }
        public string Password { get; set; }
    }
}