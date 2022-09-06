using AuthHub.BLL.Common.Extensions;
using AuthHub.Models.Constants;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using System.Threading.Tasks;

namespace AuthHub.Middleware
{
    public class OrganizationAuthHandler : AuthorizationHandler<OrganizationAuthRequirement>
    {
        private readonly IHttpContextAccessor _contextAccessor;
        private readonly IAuthHubAuthenticationService _authHubAuthenticationService;

        public OrganizationAuthHandler(
            IHttpContextAccessor contextAccessor,
            IAuthHubAuthenticationService authHubAuthenticationService
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

        protected bool TryGetHeaderValues(
            out Guid organizationId,
            out string username,
            out string password
            )
        {
            organizationId = Guid.Empty;
            username = password = null;




            return true;
        }
    }

    public class OrganizationAuthRequirement : IAuthorizationRequirement
    {
    }
}
