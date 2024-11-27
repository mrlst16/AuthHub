using System.Net.Http.Headers;
using System.Net.Http.Json;
using System.Text.Json;
using AuthHub.Jobs.Models.Billing.Paypal;
using Microsoft.Extensions.Configuration;
using Newtonsoft.Json;
using Newtonsoft.Json.Serialization;

namespace AuthHub.Jobs.Jobs.Billing
{
    public class PaypalClient: IPaypalClient
    {
        private readonly IConfiguration _configuration;
        private string ClientId => _configuration.GetValue<string>("Paypal:ClientId");
        private string ClientSecret => _configuration.GetValue<string>("Paypal:ClientSecret");
        private string BaseUrl => _configuration.GetValue<string>("Paypal:BaseUrl");

        private readonly JsonSerializerSettings SerializerSettings = new JsonSerializerSettings()
        {
            ContractResolver = new DefaultContractResolver()
            {
                NamingStrategy = new SnakeCaseNamingStrategy()
            }
        };

        private readonly JsonSerializerOptions SerializerOptions = new JsonSerializerOptions()
        {
            PropertyNamingPolicy = JsonNamingPolicy.SnakeCaseLower
        };

        private PaypalAuthorizationResponse Authorization;
        private DateTime AuthorizationExpirationUTC;

        private HttpClient AuthorizedClient
        {
            get
            {
                HttpClient client = new HttpClient();
                client.BaseAddress = new Uri(BaseUrl);
                client.DefaultRequestHeaders.Authorization
                    = new AuthenticationHeaderValue("Bearer", Authorization.AccessToken);

                return client;
            }
        }

        public PaypalClient(
            IConfiguration configuration
            )
        {
            _configuration = configuration;
        }

        private static string Base64Encode(string plainText)
        {
            var plainTextBytes = System.Text.Encoding.UTF8.GetBytes(plainText);
            return System.Convert.ToBase64String(plainTextBytes);
        }

        private async Task EnsureAuthorizationAsync()
        {
            if (Authorization == null || AuthorizationExpirationUTC.AddSeconds(-50) > DateTime.UtcNow)
            {
                Authorization = await GetAuthorizationAsync();
                AuthorizationExpirationUTC = DateTime.UtcNow.AddSeconds(Authorization.ExpiresIn);
            }
        }

        public async Task<PaypalAuthorizationResponse> GetAuthorizationAsync()
        {
            using HttpClient client = new HttpClient();
            client.BaseAddress = new Uri(BaseUrl);

            client.DefaultRequestHeaders.Authorization
                = new AuthenticationHeaderValue("Basic", Base64Encode($"{ClientId}:{ClientSecret}"));

            var content = new FormUrlEncodedContent(new KeyValuePair<string, string>[]
            {
                new KeyValuePair<string, string>("grant_type", "client_credentials")
            });
            var responseTask = client.PostAsync($"v1/oauth2/token", content);
            var response = responseTask.Result;
            string json = await  response.Content.ReadAsStringAsync();

            return JsonConvert.DeserializeObject<PaypalAuthorizationResponse>(json, SerializerSettings);
        }

        public async Task<CreateDraftResponse> CreateDraftInvoiceAsync(PaypalInvoice paypalInvoice)
        {
            await EnsureAuthorizationAsync();
            string invoiceJson = JsonConvert.SerializeObject(paypalInvoice, SerializerSettings);
            HttpContent content = new StringContent(invoiceJson);
            content.Headers.ContentType = new MediaTypeHeaderValue("application/json");
            content.Headers.Add("Prefer", "return=representation");
            var response = await AuthorizedClient.PostAsync("v2/invoicing/invoices", content);
            var json = await response.Content.ReadAsStringAsync();
            //I'm putting the ensure call after the reading to debug
            response.EnsureSuccessStatusCode();
            return JsonConvert.DeserializeObject<CreateDraftResponse>(json, SerializerSettings);
        }

        public async Task<SendInvoiceResponse> SendInvoiceAsync(string invoiceId)
        {
            await EnsureAuthorizationAsync();
            var response = await AuthorizedClient.PostAsJsonAsync($"v2/invoicing/invoices/{invoiceId}/send",
                new
                {
                    send_to_invoicer = true
                },
                SerializerOptions
            );
            response.EnsureSuccessStatusCode();
            var json = await response.Content.ReadAsStringAsync();
            return JsonConvert.DeserializeObject<SendInvoiceResponse>(json);
        }
    }
}