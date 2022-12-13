using AuthHub.Api.Middleware;
using Microsoft.AspNetCore.Authorization;

namespace AuthHub.Api.Attributes
{
    public class UserCredentialsAttribute : AuthorizeAttribute
    {
        public UserCredentialsAttribute() : base()
        {
            AuthenticationSchemes = UserCredentialsAuthenticationHandler.Scheme;
        }
    }
}
