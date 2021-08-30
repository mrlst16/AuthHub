using AuthHub.Models.Passwords;
using AuthHub.Models.Tokens;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace AuthHub.SDK
{
    public class JWTTokenConnector : ITokenConnector
    {
        private readonly IApiConnector _apiConnector;
        private readonly ILocalStorageProvider _localStorageProvider;

        private const string JWTTokenKey = "audder_jwt_token";

        public JWTTokenConnector(
            IApiConnector apiConnector,
            ILocalStorageProvider localStorageProvider
            )
        {
            _apiConnector = apiConnector;
            _localStorageProvider = localStorageProvider;
        }

        public async Task<Token> GetTokenFromLocalStorage()
        {
            var token = await _localStorageProvider.GetItem<Token>(JWTTokenKey);
            if (token?.ExpirationDate > DateTime.UtcNow
                && token.EnitityID != Guid.Empty
                )
                return token;
            else
                return null;
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

            await _localStorageProvider.SetItem<Token>(JWTTokenKey, response);
            return response;
        }

        public async Task RequestPasswordReset(RequestPasswordResetRequest request)
        {
            await _apiConnector.Post<RequestPasswordResetRequest, object>("password/request_reset", request);
        }
    }
}
