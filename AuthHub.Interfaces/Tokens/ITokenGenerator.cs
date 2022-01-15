using AuthHub.Models.Organizations;
using AuthHub.Models.Passwords;
using AuthHub.Models.Tokens;
using System.Threading.Tasks;

namespace AuthHub.Interfaces.Tokens
{
    public interface ITokenGenerator
    {
        Task<Token> GetToken(PasswordRequest request, Organization organization);
        Task<Token> GetTokenForAudderClients(PasswordRequest request);
        Task<(byte[], byte[])> GetHash(PasswordRequest passwordRequest, Organization organization);
    }
}