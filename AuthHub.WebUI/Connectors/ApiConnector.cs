using AuthHub.Models.Tokens;
using AuthHub.SDK;
using Microsoft.AspNetCore.Components;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Logging;
using System;
using System.Net.Http;
using System.Threading.Tasks;

namespace AuthHub.WebUI.Connectors
{
    public class ApiConnector : ApiConnectorBase
    {

        private readonly HttpClient _httpClient;
        private readonly IConfiguration _configuration;
        private readonly ILogger<ApiConnector> _logger;
        private readonly NavigationManager _navigationManager;
        private readonly ILocalStorageProvider _localStorageProvider;

        public ApiConnector(
            HttpClient httpClient,
            IConfiguration configuration,
            NavigationManager navigationManager,
            ILocalStorageProvider localStorageProvider
            ) : base(httpClient, configuration)
        {
            _httpClient = httpClient;
            _configuration = configuration;
            _navigationManager = navigationManager;
            _localStorageProvider = localStorageProvider;
        }
        public override async Task<Token> GetTokenFromLocalStorage()
        {
            var token = await _localStorageProvider.Get<Token>(JWTTokenConnectorBase.JWTTokenKey);
            if (
                token?.ExpirationDate > DateTime.UtcNow
                    && token.EntityID != Guid.Empty
                )
                return token;
            else
                return null;
        }

        protected override async Task HandleException(Exception e)
        {
            _navigationManager.NavigateTo($"/error/{e.Message}/{e.StackTrace}");
        }

        protected virtual async Task HandleNotLoggedIn()
        {
            _navigationManager.NavigateTo($"/organization_sign_in");
        }

        private string Url(string endpoint)
            => $"{_configuration.GetValue<string>("AppSettings:ApiUrl")}/api/{endpoint}";
    }
}