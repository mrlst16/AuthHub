using AuthHub.Models.Tokens;
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
using System.Text.Json;
using System.Threading.Tasks;

namespace AuthHub.SDK
{
    public abstract class ApiConnectorBase : IApiConnector
    {
        protected readonly HttpClient _httpClient;
        protected readonly IConfiguration _configuration;
        protected readonly ITokenConnector _tokenConnector;

        public ApiConnectorBase(
            HttpClient httpClient,
            IConfiguration configuration
            )
        {
            _httpClient = httpClient;
            _configuration = configuration;
        }

        protected abstract Task HandleException(Exception e);
        public abstract Task<Token> GetTokenFromLocalStorage();

        protected virtual string Url(string endpoint, IDictionary<string, string> queryParams = null)
        {
            var result = $"{_httpClient.BaseAddress}api/{endpoint}";
            if (queryParams != null)
                result += "?" + queryParams.Select(x => $"{x.Key}={x.Value}").Aggregate((x, y) => $"{x}&{y}");

            return result;
        }

        /// <summary>
        /// This method is for Get
        /// </summary>
        /// <param name="endpoint"></param>
        /// <param name="value"></param>
        /// <param name="queryParams"></param>
        /// <param name="headers"></param>
        /// <returns></returns>
        protected virtual HttpRequestMessage AssembleHttpRequest(
            string endpoint,
            IDictionary<string, string> queryParams = null,
            IDictionary<string, string> headers = null
            )
        {
            var url = Url(endpoint, queryParams);

            var request = new HttpRequestMessage(HttpMethod.Get, url);
            request.Headers.Add("Accept", "application/json");
            request.Headers.Add("ContentType", "application/json");

            if (headers != null)
            {
                foreach (var kvp in headers)
                {
                    request.Headers.Add(kvp.Key, kvp.Value);
                }
            }
            return request;
        }

        protected virtual HttpRequestMessage AssembleHttpRequest<TIn>(
            HttpMethod method,
            string endpoint,
            TIn value,
            IDictionary<string, string> queryParams = null,
            IDictionary<string, string> headers = null
            )
        {
            var url = Url(endpoint, queryParams);

            var request = new HttpRequestMessage(method, url);
            request.Method = method;

            var jsonMediaHeader = new MediaTypeWithQualityHeaderValue("application/json");
            request.Headers.Accept.Add(jsonMediaHeader);

            if (value != null && method != HttpMethod.Get)
                request.Content = JsonContent.Create(value, jsonMediaHeader, new JsonSerializerOptions()
                {

                });

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
                var request = AssembleHttpRequest<TIn>(method, endpoint, val, queryParams, headers);

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

        protected virtual async Task CallAndReadHttp<TIn>(
            HttpMethod method,
            string endpoint,
            TIn val,
            IDictionary<string, string> queryParams = null,
            IDictionary<string, string> headers = null
            )
        {
            try
            {
                var request = AssembleHttpRequest<TIn>(method, endpoint, val, queryParams, headers);

                var httpResponse = await _httpClient.SendAsync(request);
                if (!httpResponse.IsSuccessStatusCode)
                {
                    throw new Exception($"{httpResponse.ReasonPhrase}{System.Environment.NewLine}{httpResponse.ReasonPhrase}");
                }
            }
            catch (Exception e)
            {
                await HandleException(e);
            }
        }

        public async Task<T> Get<T>(
            string endpoint,
            IDictionary<string, string> queryParams = null,
            IDictionary<string, string> headers = null)
        {
            try
            {
                var request = AssembleHttpRequest<object>(HttpMethod.Get, endpoint, null, queryParams: queryParams, headers: headers);

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
            => await CallAndReadHttp<TIn, TOut>(HttpMethod.Patch, endpoint, val, queryParams, headers);

        public async Task<TOut> Put<TIn, TOut>(string endpoint, TIn val, IDictionary<string, string> queryParams = null, IDictionary<string, string> headers = null)
            => await CallAndReadHttp<TIn, TOut>(HttpMethod.Put, endpoint, val, queryParams, headers);

        public async Task Post<TIn>(string endpoint, TIn val, IDictionary<string, string> queryParams = null, IDictionary<string, string> headers = null)
            => await CallAndReadHttp<TIn>(HttpMethod.Post, endpoint, val, queryParams, headers);

        public async Task Patch<TIn>(string endpoint, TIn val, IDictionary<string, string> queryParams = null, IDictionary<string, string> headers = null)
            => await CallAndReadHttp<TIn>(HttpMethod.Patch, endpoint, val, queryParams, headers);


        public async Task Put<TIn>(string endpoint, TIn val, IDictionary<string, string> queryParams = null, IDictionary<string, string> headers = null)
            => await CallAndReadHttp<TIn>(HttpMethod.Put, endpoint, val, queryParams, headers);


        public async Task Delete<T>(string endpoint, T val, IDictionary<string, string> queryParams = null, IDictionary<string, string> headers = null)
            => await CallAndReadHttp<T>(HttpMethod.Delete, endpoint, val, queryParams, headers);

    }
}
