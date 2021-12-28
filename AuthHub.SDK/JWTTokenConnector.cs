using AuthHub.Models.Passwords;
using AuthHub.Models.Tokens;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace AuthHub.SDK
{
    public abstract class JWTTokenConnector : ITokenConnector
    {
        private readonly IApiConnector _apiConnector;

        private const string JWTTokenKey = "audder_jwt_token";

        protected JWTTokenConnector(
            IApiConnector apiConnector
            )
        {
            _apiConnector = apiConnector;
        }

        public abstract Task<Token> GetFromStorage(string key);

        protected abstract Task<Token> GetTokenFromLocalStorage();

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
    }
}
