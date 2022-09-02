using AuthHub.Models.Tokens;
using Microsoft.Extensions.Configuration;
using System;
using System.Net.Http;
using System.Threading.Tasks;

namespace AuthHub.SDK
{
    public class WebApiConnector : ApiConnectorBase
    {
        public WebApiConnector(HttpClient httpClient, IConfiguration configuration) : base(httpClient, configuration)
        {
        }

        protected override async Task HandleException(Exception e) => throw e;
        public override async Task<Token> GetTokenFromLocalStorage(string fromPage = "")
        {
            throw new NotImplementedException();
        }
    }
}
