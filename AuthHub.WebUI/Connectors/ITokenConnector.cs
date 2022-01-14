using AuthHub.Models.Passwords;
using System.Threading.Tasks;
using AuthHubToken = AuthHub.Models.Tokens.Token;

namespace AuthHub.WebUI.Connectors
{
    public interface ITokenConnector
    {
        Task<AuthHubToken> GetTokenFromLocalStorage();
        Task<AuthHubToken> GetOrganizationToken(string username, string password);
        Task<AuthHubToken> OrganizationSignIn(string username, string password, string redirect = null);
        Task RequestPasswordReset(RequestPasswordResetRequest request);
    }
}
