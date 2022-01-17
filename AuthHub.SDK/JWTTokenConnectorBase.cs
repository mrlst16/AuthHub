using AuthHub.Models.Passwords;
using AuthHub.Models.Tokens;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace AuthHub.SDK
{
    public abstract class JWTTokenConnectorBase : ITokenConnector
    {
        protected readonly IApiConnector _apiConnector;

        protected const string JWTTokenKey = "audder_jwt_token";

        protected JWTTokenConnectorBase(
            IApiConnector apiConnector
            )
        {
            _apiConnector = apiConnector;
        }

        public async Task<Token> GetOrganizationToken(string username, string password)
        {
            var token = await GetTokenFromLocalStorage();
            if (token != null) return token;

            return await SignIn(username, password);
        }

        public async Task<Token> SignIn(string username, string password)
        {
            var response = await _apiConnector.Get<Token>("organizations/get_org_jwt_token", headers: new Dictionary<string, string>()
            {
                {Models.Constants.AuthHubHeaders.Username , username},
                {Models.Constants.AuthHubHeaders.Password , password}
            });
            return response;
        }

        public async Task RequestPasswordReset(RequestPasswordResetRequest request)
        {
            await _apiConnector.Post<RequestPasswordResetRequest, object>("password/request_reset", request);
        }

        public abstract Task<Token> GetTokenFromLocalStorage();

        public Task<Token> OrganizationSignIn(string username, string password, string redirect = null)
        {
            throw new System.NotImplementedException();
        }
    }
}
