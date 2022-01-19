using AuthHub.Models.Passwords;
using System.Collections.Generic;

namespace AuthHub.Models.Users
{
    public class UserViewModel
    {
        public User User { get; set; }
        public IEnumerable<ClaimsKey> ClaimsKeys { get; set; }
    }
}
