using AuthHub.Api.Middleware;
using Microsoft.AspNetCore.Authorization;

namespace AuthHub.Api.Attributes
{
    public class ApiAndLoggedInUserAttribute: AuthorizeAttribute
    {
        public ApiAndLoggedInUserAttribute()
        {
            AuthenticationSchemes = ApiAndLoggedInUserAuthenticationHandler.Scheme;
        }
    }
}
