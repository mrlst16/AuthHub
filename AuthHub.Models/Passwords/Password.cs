using System.Collections.Generic;
using System.Security.Claims;

namespace AuthHub.Models.Passwords
{
    public class Password
    {
        public string UserName { get; set; }
        public byte[] PasswordHash { get; set; }
        public byte[] Salt { get; set; }
        public int Iterations { get; set; }
        public int HashLength { get; set; }
        public List<Claim> Claims { get; set; } = new List<Claim>();
    }
}
