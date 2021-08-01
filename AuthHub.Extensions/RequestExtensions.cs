using Microsoft.AspNetCore.Http;
using System;

namespace AuthHub.Extensions
{
    public static class RequestExtensions
    {
        public static (string, string) GetUsernameAndPassword(this HttpRequest request)
        {
            try
            {
                var username = request.Headers[AuthHub.Models.Constants.AuthHubHeaders.Username].ToString();
                var password = request.Headers[AuthHub.Models.Constants.AuthHubHeaders.Password].ToString();
                return (username, password);
            }
            catch (Exception e)
            {
                return (null, null);
            }
        }
    }
}
