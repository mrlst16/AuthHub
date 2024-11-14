using AuthHub.Models.Constants;
using Microsoft.AspNetCore.Authentication;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Options;
using Microsoft.Extensions.Primitives;
using System.Text.Encodings.Web;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using System.Security.Claims;
using AuthHub.Interfaces.Passwords;

namespace AuthHub.Api.Middleware
{
    public class APIAndUserCredentialsOptions : AuthenticationSchemeOptions
    {
    }

    public class APIAndUserCredentialsAuthenticationHandler : AuthenticationHandler<APIAndUserCredentialsOptions>
    {
        public const string Scheme = "AuthHubApiAndUserCredentials";
        private readonly ICredentialsEvaluator _evaluator;

        public APIAndUserCredentialsAuthenticationHandler(
            ICredentialsEvaluator evaluator, 
            IOptionsMonitor<APIAndUserCredentialsOptions> options,
            ILoggerFactory logger, 
            UrlEncoder encoder,
            ISystemClock clock
        ) : base(options, logger, encoder, clock)
        {
            _evaluator = evaluator;
        }

        protected override async Task<AuthenticateResult> HandleAuthenticateAsync()
        {
            if (
                !Request.Headers.TryGetValue(AuthHubHeaders.OrganizationID,
                    out StringValues organizationIdStringValue))
                return AuthenticateResult.Fail("OrganizationId is required");
            if (!int.TryParse(organizationIdStringValue, out int organizationId))
                throw new BadHttpRequestException("OrganizationId must be a valid int value");
            if (
                !Request.Headers.TryGetValue(AuthHubHeaders.APIKey,
                    out StringValues apiKey))
                return AuthenticateResult.Fail("APIKey is required");
            if (
                !Request.Headers.TryGetValue(AuthHubHeaders.APISecret,
                    out StringValues apiSecret))
                return AuthenticateResult.Fail("APISecret is required");

            if (
                !Request.Headers.TryGetValue(AuthHubHeaders.Username,
                    out StringValues username))
                return AuthenticateResult.Fail($"{AuthHubHeaders.Username} is required");

            if (
                !Request.Headers.TryGetValue(AuthHubHeaders.Password,
                    out StringValues password))
                return AuthenticateResult.Fail($"{AuthHubHeaders.Password} is required");

            var apiAuthenticateResult = await _evaluator.EvaluateApiKeyAndSecret(organizationId, apiKey, apiSecret);

            if (!apiAuthenticateResult)
                return AuthenticateResult.Fail("Not authenticated");

            var (authenticationResult, userid) = await _evaluator.EvaluateUsernameAndPassword(organizationId, username, password);

            if (!authenticationResult)
            {
                if (userid <= 0)
                    return AuthenticateResult.Fail("Username does not exist");

                return AuthenticateResult.Fail("Not authenticated");
            }

            var principal = CreateClaimsPrincipal(username, userid, organizationId);

            AuthenticationTicket ticket = new(principal, Scheme);

            return AuthenticateResult.Success(ticket);
        }

        private ClaimsPrincipal CreateClaimsPrincipal(
            string username,
            int userId,
            int organizationId)
        {
            Claim[] claims = new Claim[]
            {
                new Claim("Username", username),
                new Claim("UserId", userId.ToString()),
                new Claim("OrganizationId", organizationId.ToString())
            };
            var identity = new ClaimsIdentity(claims, nameof(APICredentialsAuthenticationHandler));
            return new ClaimsPrincipal(identity);
        }
    }
}
