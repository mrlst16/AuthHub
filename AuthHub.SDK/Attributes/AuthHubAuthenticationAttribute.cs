using AuthHub.SDK.Handlers;
using Microsoft.AspNetCore.Authorization;

namespace AuthHub.SDK.Attributes
{
    public class AuthHubAuthenticationAttribute : AuthorizeAttribute
    {
        public AuthHubAuthenticationAttribute()
            : base()
        {
            AuthenticationSchemes = AuthHubAuthHandler.Scheme;
        }
    }
}