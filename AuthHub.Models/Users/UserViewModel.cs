using AuthHub.Models.Passwords;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AuthHub.Models.Users
{
    public class UserViewModel
    {
        public User User { get; set; }
        public IEnumerable<ClaimsKey> ClaimsKeys { get; set; }
    }
}
