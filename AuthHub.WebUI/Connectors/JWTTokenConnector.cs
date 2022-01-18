using AuthHub.Models.Passwords;
using AuthHub.Models.Tokens;
using AuthHub.SDK;
using Microsoft.AspNetCore.Components;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace AuthHub.WebUI.Connectors
{
    public class JWTTokenConnector : JWTTokenConnectorBase
    {
        private readonly IApiConnector _apiConnector;
        private readonly ILocalStorageProvider _localStorageProvider;
        private readonly NavigationManager _navigationManager;

        private const string JWTTokenKey = "audder_jwt_token";

        public JWTTokenConnector(
            IApiConnector apiConnector,
            ILocalStorageProvider localStorageProvider,
            NavigationManager navigationManager
            ) : base(apiConnector)
        {
            _apiConnector = apiConnector;
            _localStorageProvider = localStorageProvider;
            _navigationManager = navigationManager;
        }

        public async Task<Token> GetOrganizationToken(string username, string password)
        {
            var token = await _apiConnector.GetTokenFromLocalStorage();
            if (token != null) return token;

            return await OrganizationSignIn(username, password, null);
        }

        public async Task<Token> OrganizationSignIn(string username, string password, string redirect = null)
        {
            var response = await _apiConnector.Get<Token>("token/get_org_jwt_token", headers: new Dictionary<string, string>()
            {
                {Models.Constants.AuthHubHeaders.Username , username},
                {Models.Constants.AuthHubHeaders.Password , password}
            });
            if (
                !string.IsNullOrWhiteSpace(response?.Value)
                    && response.EntityID != Guid.Empty
                )
            {
                await _localStorageProvider.Save<Token>(JWTTokenKey, response);
                _navigationManager.NavigateTo($"organization_home/{response.EntityID}");
            }
            else
                return null;

            return response;
        }

        public async Task RequestPasswordReset(RequestPasswordResetRequest request)
        {
            await _apiConnector.Post<RequestPasswordResetRequest, object>("password/request_reset", request);
        }
    }
}
