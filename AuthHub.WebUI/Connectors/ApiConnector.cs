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
    public class ApiConnector : IApiConnector
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
            )
        {
            _httpClient = httpClient;
            _configuration = configuration;
            _logger = logger;
            _navigationManager = navigationManager;
        }

        public async Task<T> Get<T>(
            string endpoint,
            IDictionary<string, string> queryParams = null,
            IDictionary<string, string> headers = null)
        {
            try
            {
                var url = Url(endpoint);

                if (queryParams != null)
                    url += "?" + queryParams.Select(x => $"{x.Key}={x.Value}").Aggregate((x, y) => $"{x}&{y}");

                var request = new HttpRequestMessage(HttpMethod.Get, url);

                if (headers != null)
                {
                    foreach (var kvp in headers)
                    {
                        request.Headers.Add(kvp.Key, kvp.Value);
                    }
                }

                var httpResponse = await _httpClient.SendAsync(request);
                if (!httpResponse.IsSuccessStatusCode)
                {
                    throw new Exception($"{httpResponse.ReasonPhrase}{System.Environment.NewLine}{httpResponse.ReasonPhrase}");
                }

                var json = await httpResponse.Content.ReadAsStringAsync();
                var response = JsonConvert.DeserializeObject<ApiResponse<T>>(json);

                if (!response.Sucess)
                    throw new Exception(response.Message);
                return response.Data;
            }
            catch (Exception e)
            {
                //_logger.LogError(e.Message, e);
                //_navigationManager.NavigateTo("/error");
            }
            return default(T);
        }

        public async Task<TOut> Post<TIn, TOut>(string endpoint, TIn val)
        {
            try
            {
                var url = Url(endpoint);
                var response = await _httpClient.PostAsJsonAsync(url, val);

                if (response.IsSuccessStatusCode)
                {
                    var json = await response.Content.ReadAsStringAsync();
                    var apiResponse = JsonConvert.DeserializeObject<ApiResponse<TOut>>(json);
                    if (!apiResponse.Sucess)
                        throw new Exception(apiResponse.Message);

                    return apiResponse.Data;
                }
                else
                {
                    //_navigationManager.NavigateTo("/error");
                }
            }
            catch (Exception e)
            {
                _logger.LogError(e.Message, e);
            }
            return default(TOut);
        }

        private string Url(string endpoint)
            => $"{_configuration.GetValue<string>("AppSettings:ApiUrl")}/api/{endpoint}";
    }
}