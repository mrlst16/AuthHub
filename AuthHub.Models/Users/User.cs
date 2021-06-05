using AuthHub.Models.Passwords;

namespace AuthHub.Models.Users
{
    public class User
    {
        public string UserName { get; set; }
        public string Email { get; set; }
        public Password Password { get; set; }
    }
}
