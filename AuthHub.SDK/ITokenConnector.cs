using AuthHub.Models.Passwords;
using AuthHub.Models.Tokens;
using System.Threading.Tasks;
using AuthHubToken = AuthHub.Models.Tokens.Token;

namespace AuthHub.SDK
{
    public interface ITokenConnector
    {
        Task<AuthHubToken> GetOrganizationToken(string username, string password);
        Task<AuthHubToken> SignIn(string username, string password);
        Task RequestPasswordReset(RequestPasswordResetRequest request);
        Task<Token> GetTokenFromLocalStorage();
    }
}
