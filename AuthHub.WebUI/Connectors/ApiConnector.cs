using AuthHub.SDK;
using CommonCore.Models.Responses;
using Microsoft.AspNetCore.Components;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Logging;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Net.Http.Json;
using System.Threading.Tasks;

namespace AuthHub.WebUI.Connectors
{
    public class ApiConnector : ApiConnectorBase
    {

        private readonly HttpClient _httpClient;
        private readonly IConfiguration _configuration;
        private readonly ILogger<ApiConnector> _logger;
        private readonly NavigationManager _navigationManager;

        public ApiConnector(
            HttpClient httpClient,
            IConfiguration configuration,
            ILogger<ApiConnector> logger,
            NavigationManager navigationManager
            ) : base(httpClient, configuration)
        {
            _httpClient = httpClient;
            _configuration = configuration;
            _logger = logger;
            _navigationManager = navigationManager;
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