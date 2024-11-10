using AuthHub.Interfaces.Passwords;
using AuthHub.Models.Constants;
using Microsoft.AspNetCore.Authentication;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Options;
using Microsoft.Extensions.Primitives;
using System.Security.Claims;
using System.Text.Encodings.Web;
using System.Threading.Tasks;

namespace AuthHub.Api.Middleware
{
    public class UserCredentialsOptions : AuthenticationSchemeOptions
    {
    }

    public class UserCredentialsAuthenticationHandler : AuthenticationHandler<UserCredentialsOptions>
    {
        public const string Scheme = "UserCredentials";

        private readonly ICredentialsEvaluator _evaluator;

        public UserCredentialsAuthenticationHandler(
            ICredentialsEvaluator evaluator,
            IOptionsMonitor<UserCredentialsOptions> monitor,
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
                    out StringValues organizationIdString))
                return AuthenticateResult.Fail($"{AuthHubHeaders.OrganizationID} is required");

            if(!int.TryParse(organizationIdString, out int organizationId))
                return AuthenticateResult.Fail($"{AuthHubHeaders.OrganizationID} must be an integer");

            if (
                !Request.Headers.TryGetValue(AuthHubHeaders.Username,
                    out StringValues username))
                return AuthenticateResult.Fail($"{AuthHubHeaders.Username} is required");

            if (
                !Request.Headers.TryGetValue(AuthHubHeaders.Password,
                    out StringValues password))
                return AuthenticateResult.Fail($"{AuthHubHeaders.Username} is required");

            var (authenticationResult, userid) = await _evaluator.EvaluateUsernameAndPassword(organizationId, username, password);

            if (!authenticationResult)
            {
                if(userid <= 0)
                    return AuthenticateResult.Fail("Username does not exist");

                return AuthenticateResult.Fail("Not authenticated");
            }

            //Set up the principal
            Claim[] claims = new Claim[]
            {
                new Claim("Username", username),
                new Claim("UserId", userid.ToString()),
                new Claim("OrganizationId", organizationIdString)
            };
            var identity = new ClaimsIdentity(claims, nameof(UserCredentialsAuthenticationHandler));

            var principal = new ClaimsPrincipal(identity);

            AuthenticationTicket ticket = new(principal, Scheme);
            return AuthenticateResult.Success(ticket);
        }
    }
}
