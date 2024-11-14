using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Text;
using System.Text.Encodings.Web;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authorization;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Options;
using Microsoft.IdentityModel.Tokens;

namespace AuthHub.SDK.Handlers
{
    public class AuthHubAuthHandlerOptions: AuthenticationSchemeOptions
    {
        public string Issuer { get; set; }
        public string Audience { get; set; }
        public string Key { get; set; }
    }

    public class AuthHubAuthHandler : AuthenticationHandler<AuthHubAuthHandlerOptions>
    {
        public const string Scheme = "AuthHub";

        public AuthHubAuthHandler(
            IOptionsMonitor<AuthHubAuthHandlerOptions> options, 
            ILoggerFactory logger, 
            UrlEncoder encoder, 
            ISystemClock clock
            ) : base(options, logger, encoder, clock)
        {
        }

        public AuthHubAuthHandler(
            IOptionsMonitor<AuthHubAuthHandlerOptions> options,
            ILoggerFactory logger,
            UrlEncoder encoder) : base(options, logger, encoder)
        {
        }

        protected override async Task<AuthenticateResult> HandleAuthenticateAsync()
        {
            var authHeader = Request.Headers.Authorization.FirstOrDefault();
            if( authHeader == null)
                return AuthenticateResult.Fail("Authorization header is required");

            string? jwt = authHeader.Split(' ').LastOrDefault()?.Trim() ?? null;
            if(jwt == null)
                return AuthenticateResult.Fail("Token is required in authorization header");

            TokenValidationParameters validationParameters = new TokenValidationParameters
            {
                ValidIssuer = Options.Issuer,
                ValidAudience = Options.Audience,
                IssuerSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(Options.Key)),
                ValidateIssuer = true,
                ValidateAudience = true,
                ValidateLifetime = true,
                ValidateIssuerSigningKey = true
            };

            var handler = new JwtSecurityTokenHandler();
            try
            {
                var result = handler.ValidateToken(jwt, validationParameters, out var validatedToken);
                return AuthenticateResult.Success(new(result, Scheme));
            }
            catch (Exception e)
            {
                return AuthenticateResult.Fail(e.Message);
            }
        }
    }
}