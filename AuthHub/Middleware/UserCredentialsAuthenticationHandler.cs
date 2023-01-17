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
                !Request.Headers.TryGetValue(AuthHubHeaders.AuthSettingsID,
                    out StringValues authSettingsIDStringValue))
                return AuthenticateResult.Fail("AuthSettingsID is required");

            if (!Guid.TryParse(authSettingsIDStringValue, out Guid authSettingsId))
                return AuthenticateResult.Fail("AuthSettingsID must be a valid Guid value");

            if (
                !Request.Headers.TryGetValue(AuthHubHeaders.Username,
                    out StringValues username))
                return AuthenticateResult.Fail("UserName is required");

            if (
                !Request.Headers.TryGetValue(AuthHubHeaders.Password,
                    out StringValues password))
                return AuthenticateResult.Fail("Password is required");

            var (authenticationResult, userid) = await _evaluator.EvaluateUsernameAndPassword(authSettingsId, username, password);

            if (!authenticationResult)
                return AuthenticateResult.Fail("Not authenticated");

            //Set up the principal
            Claim[] claims = new Claim[]
            {
                new Claim("AuthSettingsID", authSettingsIDStringValue),
                new Claim("Username", username),
                new Claim("UserId", userid.ToString())
            };
            var identity = new ClaimsIdentity(claims, nameof(UserCredentialsAuthenticationHandler));

            var principal = new ClaimsPrincipal(identity);

            AuthenticationTicket ticket = new(principal, Scheme);
            return AuthenticateResult.Success(ticket);
        }
    }
}
