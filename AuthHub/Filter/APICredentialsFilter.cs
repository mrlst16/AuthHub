using System.Threading.Tasks;
using AuthHub.Models.Constants;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc.Filters;
using Microsoft.Extensions.Primitives;

namespace AuthHub.Api.Filter
{
    public class APICredentialsFilter : IAsyncActionFilter
    {
        public async Task OnActionExecutionAsync(ActionExecutingContext context, ActionExecutionDelegate next)
        {
            if (
                !context.HttpContext.Request.Headers.TryGetValue(AuthHubHeaders.OrganizationID,
                    out StringValues organizationIdStringValue))
                throw new BadHttpRequestException("OrganizationId is required");
            if (!Guid.TryParse(organizationIdStringValue, out Guid organizationId))
                throw new BadHttpRequestException("OrganizationId must be a valid Guid");
            if (
                !context.HttpContext.Request.Headers.TryGetValue(AuthHubHeaders.APIKey,
                    out StringValues apiKey))
                throw new BadHttpRequestException("APIKey is required");
            if (
                !context.HttpContext.Request.Headers.TryGetValue(AuthHubHeaders.APISecret,
                    out StringValues apiSecret))
                throw new BadHttpRequestException("APISecret is required");
            


        }
    }
}
