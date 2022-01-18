using AuthHub.Models.Passwords;
using AuthHub.Models.Tokens;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace AuthHub.SDK
{
    public abstract class JWTTokenConnectorBase : ITokenConnector
    {
        protected readonly IApiConnector _apiConnector;

        public const string JWTTokenKey = "audder_jwt_token";

        protected JWTTokenConnectorBase(
            IApiConnector apiConnector
            )
        {
            _apiConnector = apiConnector;
        }

        public async Task<Token> GetOrganizationToken(string username, string password)
        {
            var token = await _apiConnector.GetTokenFromLocalStorage();
            if (token != null) return token;

            return await OrganizationSignIn(username, password);
        }

        public async Task RequestPasswordReset(RequestPasswordResetRequest request)
        {
            await _apiConnector.Post<RequestPasswordResetRequest, object>("password/request_reset", request);
        }

        public async Task<Token> OrganizationSignIn(string username, string password, string redirect = null)
        {
            var response = await _apiConnector.Get<Token>("organizations/get_org_jwt_token", headers: new Dictionary<string, string>()
            {
                {Models.Constants.AuthHubHeaders.Username , username},
                {Models.Constants.AuthHubHeaders.Password , password}
            });
            return response;
        }
    }
}
