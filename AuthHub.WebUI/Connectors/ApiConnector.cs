using AuthHub.Models.Tokens;
using AuthHub.SDK;
using Microsoft.AspNetCore.Components;
using Microsoft.Extensions.Configuration;
using System;
using System.Diagnostics;
using System.Net.Http;
using System.Runtime.CompilerServices;
using System.Threading.Tasks;

namespace AuthHub.WebUI.Connectors
{
    public class ApiConnector : ApiConnectorBase
    {
        private readonly NavigationManager _navigationManager;
        private readonly ILocalStorageProvider _localStorageProvider;
        public ApiConnector(
            HttpClient httpClient,
            IConfiguration configuration,
            NavigationManager navigationManager,
            ILocalStorageProvider localStorageProvider
            ) : base(httpClient, configuration)
        {
            _navigationManager = navigationManager;
            _localStorageProvider = localStorageProvider;
        }

        public override async Task<Token> GetTokenFromLocalStorage(string fromPage = "")
        {
            var token = await _localStorageProvider.Get<Token>(JWTTokenConnectorBase.JWTTokenKey);
            if (
                token?.ExpirationDate > DateTime.UtcNow
                    && token.EntityID != Guid.Empty
                )
                return token;
            else
            {
                await HandleNotLoggedIn(fromPage);
                return null;
            }
        }

        protected override async Task HandleException(Exception e)
        {
            _navigationManager.NavigateTo($"/error/{e.Message}/{e.StackTrace}");
        }

        protected virtual async Task HandleNotLoggedIn(string option = "")
        {
            if (string.IsNullOrWhiteSpace(option))
                _navigationManager.NavigateTo($"/organization_signin");
            switch (option)
            {
                case "user":
                case string opt1 when opt1.ToLowerInvariant().Contains("user"):
                    _navigationManager.NavigateTo($"/user_signin");
                    break;
                case string opt3 when string.IsNullOrWhiteSpace(opt3):
                case string opt2 when opt2.ToLowerInvariant().Contains("organization"):
                case "organization":
                default:
                    _navigationManager.NavigateTo($"/organization_signin");
                    break;
            }
        }
    }
}