using AuthHub.Interfaces.Tokens;
using AuthHub.Models.Organizations;
using AuthHub.Models.Passwords;
using AuthHub.Models.Tokens;
using System;
using System.Threading.Tasks;

namespace AuthHub.BLL.Tokens
{
    public class Argon2idTokenGenerator : ITokenGenerator
    {
        public async Task<(byte[], byte[])> GetHash(PasswordRequest passwordRequest, Organization organization)
        {
            throw new NotImplementedException();
        }

        public async Task<Token> GetToken(PasswordRequest request, Organization organization)
        {
            throw new NotImplementedException();
        }
    }
}
