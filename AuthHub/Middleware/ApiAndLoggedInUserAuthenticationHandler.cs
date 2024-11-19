using Azure.Core;
using Microsoft.AspNetCore.Authentication;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Options;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Text;
using System.Text.Encodings.Web;
using System.Threading.Tasks;
using AuthHub.Interfaces.AuthSetting;
using AuthHub.Models.Constants;
using Microsoft.Extensions.Primitives;
using AuthHub.Interfaces.Passwords;
using AuthHub.Models.Entities.Organizations;
using System.Security.Claims;
using AuthHub.Api.Helpers;

namespace AuthHub.Api.Middleware
{
    public class ApiAndLoggedInUserAuthenticationHandlerOptions : AuthenticationSchemeOptions
    {
    }

    /// <summary>
    /// Validates api credentials and the user's bearer token
    /// </summary>
    public class ApiAndLoggedInUserAuthenticationHandler: AuthenticationHandler<ApiAndLoggedInUserAuthenticationHandlerOptions>
    {
        private readonly IAuthSettingsContext _authSchemeContext;
        private readonly ICredentialsEvaluator _evaluator;
        public const string Scheme = "ApiAndLoggedInUser";

        public ApiAndLoggedInUserAuthenticationHandler(
            IOptionsMonitor<ApiAndLoggedInUserAuthenticationHandlerOptions> options, 
            ILoggerFactory logger,
            UrlEncoder encoder,
            ISystemClock clock,
            IAuthSettingsContext authSchemeContext,
            ICredentialsEvaluator evaluator
            ) : base(options, logger, encoder, clock)
        {
            _authSchemeContext = authSchemeContext;
            _evaluator = evaluator;
            
        }

        protected override async Task<AuthenticateResult> HandleAuthenticateAsync()
        {
            if (
                !Request.Headers.TryGetValue(AuthHubHeaders.OrganizationID,
                    out StringValues organizationIdStringValue))
                return AuthenticateResult.Fail("OrganizationId is required");

            if (!int.TryParse(organizationIdStringValue, out int organizationId))
                return AuthenticateResult.Fail("OrganizationId must be a valid int value");

            if (
                !Request.Headers.TryGetValue(AuthHubHeaders.APIKey,
                    out StringValues apiKey))
                return AuthenticateResult.Fail("APIKey is required");

            if (
                !Request.Headers.TryGetValue(AuthHubHeaders.APISecret,
                    out StringValues apiSecret))
                return AuthenticateResult.Fail("APISecret is required");

            
            var apiAuthenticateResult = await _evaluator.EvaluateApiKeyAndSecret(organizationId, apiKey, apiSecret);

            if (!apiAuthenticateResult)
                return AuthenticateResult.Fail("Not authenticated");


            var authHeader = Request.Headers.Authorization.FirstOrDefault();
            if (authHeader == null)
                return AuthenticateResult.Fail("Authorization header is required");

            string? jwt = authHeader.Split(' ').LastOrDefault()?.Trim() ?? null;
            if (jwt == null)
                return AuthenticateResult.Fail("Token is required in authorization header");

            AuthSettings authSettings = await _authSchemeContext.GetAuthSettingsAsync(organizationId);

            TokenValidationParameters validationParameters = new TokenValidationParameters
            {
                ValidIssuer = authSettings.Issuer,
                ValidAudience = authSettings.Audience,
                IssuerSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(authSettings.Key)),
                ValidateIssuer = true,
                ValidateAudience = true,
                ValidateLifetime = true,
                ValidateIssuerSigningKey = true
            };

            try
            {
                var handler = new JwtSecurityTokenHandler();
                var result = handler.ValidateToken(jwt, validationParameters, out var validatedToken);
                
                return AuthenticateResult.Success(new(result, Scheme));
            }
            catch (Exception e)
            {
                return AuthenticateResult.Fail(e.Message);
            }
        }

        private ClaimsPrincipal CreateClaimsPrincipal(
            string organizationId,
            ClaimsPrincipal parsedClaimsPrincipal
            )
        {
            Claim[] claims = new Claim[]
            {
                new Claim("OrganizationId", organizationId),
                new Claim("UserId", parsedClaimsPrincipal.GetUserId().ToString())
            };
            var identity = new ClaimsIdentity(claims, nameof(APICredentialsAuthenticationHandler));
            return new ClaimsPrincipal(identity);
        }
    }
}
