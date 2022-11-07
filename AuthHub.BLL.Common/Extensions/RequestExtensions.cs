using Microsoft.AspNetCore.Http;
using System.Text;

namespace AuthHub.BLL.Common.Extensions
{
    public static class RequestExtensions
    {
        public static (string?, string?) GetUsernameAndPassword(this HttpRequest request)
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

        public static bool TryParseBasicAuthHeader(
            this HttpRequest request,
            out string? username,
            out string? password
            )
        {
            username = password = null;

            var authHeader = request.Headers["Authorization"];
            if (string.IsNullOrEmpty(authHeader))
                return false;

            var strings = authHeader.ToString().Split(' ');
            if (strings.Length != 2) return false;

            var base64EncodedUsernameAndPassword = strings.Last();

            var bytes = Convert.FromBase64String(base64EncodedUsernameAndPassword);
            var decodedUsernameAndPassword = Encoding.UTF8.GetString(bytes);

            var decodedStrings = decodedUsernameAndPassword.Split(':');
            username = decodedStrings[0];
            password = decodedStrings[1];

            return true;
        }

        public static bool TryParseAuthSettingsId(
            this HttpRequest request,
            out Guid result
        )
        {
            result = Guid.Empty;

            return true;
        }
    }
}
