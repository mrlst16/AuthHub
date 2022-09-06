global using System;
global using IAuthHubAuthenticationService = AuthHub.Interfaces.Auth.IAuthenticationService;
global using TokenServiceFactory = System.Func<AuthHub.Models.Enums.AuthSchemeEnum, AuthHub.Interfaces.Tokens.ITokenService>;
global using TokenGeneratorFactory = System.Func<AuthHub.Models.Enums.AuthSchemeEnum, AuthHub.Interfaces.Tokens.ITokenGenerator>;
