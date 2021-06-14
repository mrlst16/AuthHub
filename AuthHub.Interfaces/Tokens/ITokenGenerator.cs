using AuthHub.Models.Organizations;
using AuthHub.Models.Passwords;
using System.Threading.Tasks;

namespace AuthHub.Interfaces.Tokens
{
    public interface ITokenGenerator
    {
        Task<string> GetToken(PasswordRequest request, Organization organization);
        Task<(byte[], byte[])> GetHash(PasswordRequest passwordRequest, Organization organization);
    }
}