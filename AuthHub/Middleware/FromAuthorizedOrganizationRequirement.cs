using Microsoft.AspNetCore.Authorization;
using System.Linq;
using System.Threading.Tasks;

namespace AuthHub.Middleware
{
    public class FromAuthorizedOrganizationHandler : AuthorizationHandler<FromAuthorizedOrganizationRequirement>
    {
        protected override async Task HandleRequirementAsync(AuthorizationHandlerContext context, FromAuthorizedOrganizationRequirement requirement)
        {

            context.Succeed(requirement);
        }
    }

    public class FromAuthorizedOrganizationRequirement : IAuthorizationRequirement
    {

    }
}
