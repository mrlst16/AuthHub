using AuthHub.BLL.Common.Extensions;
using AuthHub.Interfaces.Auth;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using System.Threading.Tasks;

namespace AuthHub.Api.Middleware
{
    public class OrganizationAuthHandler : AuthorizationHandler<OrganizationAuthRequirement>
    {
        private readonly IHttpContextAccessor _contextAccessor;
        private readonly IAuthenticationService _authHubAuthenticationService;

        public OrganizationAuthHandler(
            IHttpContextAccessor contextAccessor,
            IAuthenticationService authHubAuthenticationService
            )
        {
            _contextAccessor = contextAccessor;
            _authHubAuthenticationService = authHubAuthenticationService;
        }

        protected override async Task HandleRequirementAsync(AuthorizationHandlerContext context, OrganizationAuthRequirement requirement)
        {
            if (
                (_contextAccessor?.HttpContext?.Request?.TryParseBasicAuthHeader(out string username, out string password) ?? false)
                    && (await _authHubAuthenticationService.AuthenticateOrganization(username, password)))
            {
                context.Succeed(requirement);
                return;
            }
            context.Fail();
        }
    }

    public class OrganizationAuthRequirement : IAuthorizationRequirement
    {
    }
}
