using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Net.Http.Json;
using System.Text.Json;
using System.Threading.Tasks;

namespace AuthHub.WebUI.Connectors
{
    public class ApiConnector : IApiConnector
    {

        private readonly HttpClient _httpClient;
        private readonly IConfiguration _configuration;
        private readonly ILogger<ApiConnector> _logger;

        public ApiConnector(
            HttpClient httpClient,
            IConfiguration configuration,
            ILogger<ApiConnector> logger
            )
        {
            _httpClient = httpClient;
            _configuration = configuration;
            _logger = logger;
        }

        public async Task<T> Get<T>(string endpoint, IDictionary<string, string> headers = null)
        {
            try
            {
                if (headers != null)
                    endpoint += "?" + headers.Select(x => $"{x.Key}={x.Value}").Aggregate((x, y) => $"{x}&{y}");

                var response = await _httpClient.GetFromJsonAsync<T>(Url(endpoint));
                return response;
            }
            catch (Exception e)
            {
                _logger.LogError(e.Message, e);
            }
            return default(T);
        }

        public async Task<TOut> Post<TIn, TOut>(string endpoint, TIn val)
        {
            try
            {
                var response = await _httpClient.PostAsJsonAsync(Url(endpoint), val);
                var stream = await response.Content.ReadAsStreamAsync();
                return await JsonSerializer.DeserializeAsync<TOut>(stream);
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
