using System.Security.Authentication;
using AuthHub.Models.Constants;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Primitives;
using System.Threading.Tasks;
using AuthHub.Interfaces.Passwords;

namespace AuthHub.Api.Middleware
{
    public class APICredentialsMiddleware
    {

        private readonly IApiCredentialsEvaluator _evaluator;

        public APICredentialsMiddleware(
            IApiCredentialsEvaluator evaluator
            )
        {
            _evaluator = evaluator;
        }

        public async Task Handle(HttpContext context, Func<Task> next)
        {
            if (
                !context.Request.Headers.TryGetValue(AuthHubHeaders.OrganizationID,
                    out StringValues organizationIdStringValue))
                throw new BadHttpRequestException("OrganizationId is required");
            if (!Guid.TryParse(organizationIdStringValue, out Guid organizationId))
                throw new BadHttpRequestException("OrganizationId must be a valid Guid");
            if (
                !context.Request.Headers.TryGetValue(AuthHubHeaders.APIKey,
                    out StringValues apiKey))
                throw new BadHttpRequestException("APIKey is required");
            if (
                !context.Request.Headers.TryGetValue(AuthHubHeaders.APISecret,
                    out StringValues apiSecret))
                throw new BadHttpRequestException("APISecret is required");

            var authenticationResult = await _evaluator.Evaluate(organizationId, apiKey, apiSecret);
            if (!authenticationResult) throw new AuthenticationException();
            await next();
        }
    }
}
