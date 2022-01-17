using CommonCore.Models.Responses;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Logging;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Net.Http.Json;
using System.Threading.Tasks;

namespace AuthHub.SDK
{
    public abstract class ApiConnectorBase : IApiConnector
    {
        protected readonly HttpClient _httpClient;
        protected readonly IConfiguration _configuration;

        public ApiConnectorBase(
            HttpClient httpClient,
            IConfiguration configuration
            )
        {
            _httpClient = httpClient;
            _configuration = configuration;
        }

        protected abstract Task HandleException(Exception e);

        protected virtual string Url(string endpoint, IDictionary<string, string> queryParams = null)
        {
            var result = $"{_configuration.GetValue<string>("AppSettings:ApiUrl")}/api/{endpoint}";
            if (queryParams != null)
                result += "?" + queryParams.Select(x => $"{x.Key}={x.Value}").Aggregate((x, y) => $"{x}&{y}");

            return result;
        }

        protected HttpRequestMessage AssembleHttpRequest<TIn>(
            HttpMethod method,
            string endpoint,
            TIn value,
            IDictionary<string, string> queryParams = null,
            IDictionary<string, string> headers = null
            )
        {
            var url = Url(endpoint, headers);

            var request = new HttpRequestMessage(method, url);
            request.Content.Headers.ContentType = MediaTypeHeaderValue.Parse("application/json");
            request.Content = new StringContent(JsonConvert.SerializeObject(value));

            if (headers != null)
            {
                foreach (var kvp in headers)
                {
                    request.Headers.Add(kvp.Key, kvp.Value);
                }
            }
            return request;
        }

        protected virtual async Task<TOut> CallAndReadHttp<TIn, TOut>(
            HttpMethod method,
            string endpoint,
            TIn val,
            IDictionary<string, string> queryParams = null,
            IDictionary<string, string> headers = null
            )
        {
            try
            {
                var request = AssembleHttpRequest(method, endpoint, queryParams, headers);

                var httpResponse = await _httpClient.SendAsync(request);
                if (!httpResponse.IsSuccessStatusCode)
                {
                    throw new Exception($"{httpResponse.ReasonPhrase}{System.Environment.NewLine}{httpResponse.ReasonPhrase}");
                }

                var json = await httpResponse.Content.ReadAsStringAsync();
                var response = JsonConvert.DeserializeObject<ApiResponse<TOut>>(json);

                if (!response.Sucess)
                    throw new Exception(response.Message);
                return response.Data;
            }
            catch (Exception e)
            {
                await HandleException(e);
            }
            return default(TOut);
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
                await HandleException(e);
            }
            return default(T);
        }

        public async Task<TOut> Post<TIn, TOut>(string endpoint, TIn val, IDictionary<string, string> queryParams = null, IDictionary<string, string> headers = null)
            => await CallAndReadHttp<TIn, TOut>(HttpMethod.Post, endpoint, val, queryParams, headers);

        public async Task<TOut> Patch<TIn, TOut>(string endpoint, TIn val, IDictionary<string, string> queryParams = null, IDictionary<string, string> headers = null)
            => await CallAndReadHttp<TIn, TOut>(HttpMethod.Post, endpoint, val, queryParams, headers);

        public async Task<TOut> Put<TIn, TOut>(string endpoint, TIn val, IDictionary<string, string> queryParams = null, IDictionary<string, string> headers = null)
            => await CallAndReadHttp<TIn, TOut>(HttpMethod.Post, endpoint, val, queryParams, headers);

    }
}