using AuthHub.Interfaces.Passwords;
using AuthHub.Models.Constants;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Options;
using Microsoft.Extensions.Primitives;
using System.Security.Claims;
using System.Text.Encodings.Web;
using System.Threading.Tasks;

namespace AuthHub.Api.Middleware
{
    public class APICredentialsOptions : AuthenticationSchemeOptions
    {
    }

    public class APICredentialsAuthenticationHandler : AuthenticationHandler<APICredentialsOptions>
    {
        public const string Scheme = "AuthHubApiCredentials";

        private readonly IApiCredentialsEvaluator _evaluator;

        public APICredentialsAuthenticationHandler(
            IApiCredentialsEvaluator evaluator,
            IOptionsMonitor<APICredentialsOptions> monitor,
            ILoggerFactory loggerFactory,
            UrlEncoder urlEncoder,
            ISystemClock systemClock
            ) : base(
                monitor,
                loggerFactory,
                urlEncoder,
                systemClock
            )
        {
            _evaluator = evaluator;
        }

        protected override async Task<AuthenticateResult> HandleAuthenticateAsync()
        {
            if (
                !Request.Headers.TryGetValue(AuthHubHeaders.OrganizationID,
                    out StringValues organizationIdStringValue))
                return AuthenticateResult.Fail("OrganizationId is required");
            if (!Guid.TryParse(organizationIdStringValue, out Guid organizationId))
                throw new BadHttpRequestException("OrganizationId must be a valid Guid");
            if (
                !Request.Headers.TryGetValue(AuthHubHeaders.APIKey,
                    out StringValues apiKey))
                return AuthenticateResult.Fail("APIKey is required");
            if (
                !Request.Headers.TryGetValue(AuthHubHeaders.APISecret,
                    out StringValues apiSecret))
                return AuthenticateResult.Fail("APISecret is required");

            var authenticationResult = await _evaluator.Evaluate(organizationId, apiKey, apiSecret);

            if (!authenticationResult)
                return AuthenticateResult.Fail("Not authenticated");

            var principal = CreateClaimsPrincipal(organizationIdStringValue);
            AuthenticationTicket ticket = new(principal, Scheme);

            return AuthenticateResult.Success(ticket);
        }

        private ClaimsPrincipal CreateClaimsPrincipal(string organizationId)
        {
            Claim[] claims = new Claim[]
            {
                new Claim("OrganizationId", organizationId)
            };
            var identity = new ClaimsIdentity(claims, nameof(APICredentialsAuthenticationHandler));
            return new ClaimsPrincipal(identity);
        }
    }
}
