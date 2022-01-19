using AuthHub.Models.Tokens;
using AuthHub.SDK;
using Microsoft.AspNetCore.Components;
using System;
using System.Threading.Tasks;

namespace AuthHub.WebUI.Connectors
{
    public class JWTTokenConnector : JWTTokenConnectorBase
    {
        private readonly ILocalStorageProvider _localStorageProvider;
        private readonly NavigationManager _navigationManager;

        public JWTTokenConnector(
            IApiConnector apiConnector,
            ILocalStorageProvider localStorageProvider,
            NavigationManager navigationManager
            ) : base(apiConnector)
        {
            _localStorageProvider = localStorageProvider;
            _navigationManager = navigationManager;
        }

        public override async Task<Token> OrganizationSignIn(string username, string password)
        {
            var result = await base.OrganizationSignIn(username, password);

            if (
                !string.IsNullOrWhiteSpace(result?.Value)
                    && result.EntityID != Guid.Empty
                )
            {
                await _localStorageProvider.Save<Token>(JWTTokenKey, result);
                _navigationManager.NavigateTo($"organization_home/{result.EntityID}");
            }
            else
            {
                _navigationManager.NavigateTo($"organization_sign_in/{result.EntityID}");
            }

            return result;
        }
    }
}
