using System.Collections.Generic;
using AuthHub.Models.Passwords;

namespace AuthHub.Models.Requests
{
    public class LoginChallengeResponse
    {
        public byte[] StoredPasswordHash { get; set; }
        public byte[] Salt { get; set; }
        public int Iterations { get; set; }
        public int Length { get; set; }
        public IEnumerable<ClaimsEntity> Claims { get; set; }
        public string UserName { get; set; }
        public string Issuer { get; set; }
    }
}
