global using System;
global using IAuthHubAuthenticationService = AuthHub.Interfaces.Auth.IAuthenticationService;
global using TokenGeneratorFactory = System.Func<AuthHub.Models.Enums.AuthSchemeEnum, AuthHub.Interfaces.Tokens.ITokenGenerator>;
global using TokenServiceFactory = System.Func<AuthHub.Models.Enums.AuthSchemeEnum, AuthHub.Interfaces.Tokens.ITokenService>;
