using AuthHub.Models.Passwords;
using Common.Models.Responses;
using System.Collections.Generic;

namespace AuthHub.Models.Users
{
    public class UserViewModel : IViewModel
    {
        public User User { get; set; } = new User();
        public IEnumerable<ClaimsKey> ClaimsKeys { get; set; }
            = new List<ClaimsKey>();
    }
}
