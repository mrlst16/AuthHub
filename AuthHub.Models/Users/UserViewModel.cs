using AuthHub.Models.Passwords;
using System.Collections.Generic;
using Common.Models.Responses;

namespace AuthHub.Models.Users
{
    public class UserViewModel : IViewModel
    {
        public User User { get; set; } = new User();
        public IEnumerable<ClaimsKey> ClaimsKeys { get; set; }
            = new List<ClaimsKey>();
    }
}
