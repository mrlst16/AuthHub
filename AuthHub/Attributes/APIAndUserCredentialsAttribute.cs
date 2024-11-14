using AuthHub.Api.Middleware;
using Microsoft.AspNetCore.Authorization;

namespace AuthHub.Api.Attributes
{
    public class APIAndUserCredentialsAttribute: AuthorizeAttribute
    {

        public APIAndUserCredentialsAttribute()
        {
            AuthenticationSchemes = APIAndUserCredentialsAuthenticationHandler.Scheme;
        }
    }
}