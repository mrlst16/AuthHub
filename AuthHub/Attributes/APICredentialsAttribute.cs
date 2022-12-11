using AuthHub.Api.Middleware;
using Microsoft.AspNetCore.Authorization;

namespace AuthHub.Api.Attributes
{
    public class APICredentialsAttribute : AuthorizeAttribute
    {
        public APICredentialsAttribute(): base()
        {
            AuthenticationSchemes = APICredentialsAuthenticationHandler.Scheme;
        }
    }
}