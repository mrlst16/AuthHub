using System;

namespace AuthHub.Models.Requests
{
    public class CreateUserRequest
    {
        public string Email { get; set; }
        public string PhoneNumber { get; set; }
        public string UserName { get; set; }
        public string Password { get; set; }
        public string Data { get; set; }
        public string ClaimsTemplateName { get; set; }
    }
}
