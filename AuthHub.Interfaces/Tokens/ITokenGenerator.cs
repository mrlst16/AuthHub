using AuthHub.Models.Organizations;
using AuthHub.Models.Passwords;
using AuthHub.Models.Tokens;
using System;
using System.Threading.Tasks;

namespace AuthHub.Interfaces.Tokens
{
    public interface ITokenGenerator
    {
        Task<Token> GetToken(Guid authSettings, string userName, string password);
        Task<Token> GetTokenForAudderClients(string userName, string password);
        Task<(byte[], byte[])> GetHash(PasswordRequest passwordRequest, Organization organization);
    }
}
