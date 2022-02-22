using AuthHub.BLL.Common.Extensions;
using AuthHub.Common.Extensions;
using AuthHub.Interfaces.Organizations;
using AuthHub.Interfaces.Passwords;
using AuthHub.Interfaces.Tokens;
using AuthHub.Interfaces.Users;
using AuthHub.Models.Organizations;
using AuthHub.Models.Passwords;
using AuthHub.Models.Tokens;
using CommonCore.Interfaces.Helpers;
using CommonCore2.Extensions;
using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Security.Cryptography;
using System.Text;

namespace AuthHub.BLL.Common.Tokens
{
    public class JWTTokenGenerator : ITokenGenerator
    {
        private readonly IOrganizationLoader _organizationLoader;
        private readonly IPasswordLoader _passwordLoader;
        private readonly IUserLoader _userLoader;
        private readonly IConfiguration _configuration;
        private readonly IApplicationConsistency _applicationConsistency;

        public JWTTokenGenerator(
            IOrganizationLoader organizationLoader,
            IPasswordLoader passwordLoader,
            IUserLoader userLoader,
            IConfiguration configuration,
            IApplicationConsistency applicationConsistency
            )
        {
            _organizationLoader = organizationLoader;
            _passwordLoader = passwordLoader;
            _userLoader = userLoader;
            _configuration = configuration;
            _applicationConsistency = applicationConsistency;
        }

        public async Task<Token> GetTokenForAudderClients(PasswordRequest request)
        {
            var authHubOrgId = _configuration.AuthHubOrganizationId();

            try
            {
                var passwordRecord = await _passwordLoader.Get(request.OrganizationID, request.SettingsName, request.UserName);
                var authSettings = await _organizationLoader.GetSettings(authHubOrgId, "audder_clients");

                if (!Authenticate
                        (
                            passwordRecord.PasswordHash,
                            request.Password,
                            passwordRecord.Salt,
                            authSettings.HashLength,
                            authSettings.Iterations
                            )
                        )
                    throw new Exception($"Username and Password are not a match for user {request.UserName} while logging in as an ogranization");

                if (passwordRecord.Claims == null)
                    passwordRecord.Claims = new List<ClaimsEntity>();
                if (
                    passwordRecord.Claims
                        .FirstOrDefault(x => string.Equals(x.Key, "Name", StringComparison.InvariantCultureIgnoreCase)
                            ) == null)
                    passwordRecord.Claims.Add(_configuration.CreateClaimsEntity("Name", request.UserName));

                passwordRecord.Claims = passwordRecord?.Claims?.Where(x => !string.IsNullOrWhiteSpace(x.Key)).ToList();


                var securityKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(authSettings.Key));
                var credentials = new SigningCredentials(securityKey, SecurityAlgorithms.HmacSha256);

                var token = new JwtSecurityToken(
                    issuer: authSettings.Issuer,
                    audience: authSettings.Issuer,
                    claims: passwordRecord.GetClaims(),
                    expires: DateTime.Now.AddMinutes(authSettings.ExpirationMinutes),
                    signingCredentials: credentials
                    );

                var user = await _userLoader.Get(request.OrganizationID, authSettings.Name, request.UserName);

                var val = new JwtSecurityTokenHandler().WriteToken(token);
                return new Token(val, token.ValidTo, user.UsersOrganizationId);
            }
            catch (Exception e)
            {
                throw;
            }
        }

        public async Task<Token> GetToken(PasswordRequest request, Organization organization)
        {
            try
            {
                var passwordRecord = await _passwordLoader.Get(request.OrganizationID, request.SettingsName, request.UserName);

                throw new Exception($"Username and Password are not a match for user {request.UserName} in organization {organization.ID}");

                if (passwordRecord.Claims == null)
                    passwordRecord.Claims = new List<ClaimsEntity>();
                if (passwordRecord.Claims.FirstOrDefault(x => x.Key == ClaimTypes.Name) == null)
                    passwordRecord.Claims.Add(_configuration.CreateClaimsEntity("Name", request.UserName));

                passwordRecord.Claims = passwordRecord?.Claims?.Where(x => !string.IsNullOrWhiteSpace(x.Key)).ToList();

                var authSettings = await _organizationLoader.GetSettings(request.OrganizationID, request.SettingsName);

                var securityKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(authSettings.Key));
                var credentials = new SigningCredentials(securityKey, SecurityAlgorithms.HmacSha256);

                var token = new JwtSecurityToken(
                    issuer: authSettings.Issuer,
                    audience: authSettings.Issuer,
                    claims: passwordRecord.GetClaims(),
                    expires: DateTime.Now.AddMinutes(authSettings.ExpirationMinutes),
                    signingCredentials: credentials
                    );

                var val = new JwtSecurityTokenHandler().WriteToken(token);
                return new Token(val, token.ValidTo, organization.ID);
            }
            catch (Exception e)
            {
                throw;
            }
        }

        private byte[] RandomSalt(int length)
        {
            byte[] result = new byte[length];

            using (var rng = new RNGCryptoServiceProvider())
            {
                rng.GetBytes(result);
            }
            return result;
        }

        public byte[] GenerateHash(byte[] password, byte[] salt, int length, int iterations = 100)
        {
            byte[] result = new byte[length];

            using (var derviedBytes = new Rfc2898DeriveBytes(password, salt, iterations))
            {
                result = derviedBytes.GetBytes(length);
            }

            return result;
        }

        public byte[] GenerateHash(string password, byte[] salt, int length, int iterations = 100)
            => GenerateHash(_applicationConsistency.GetBytes(password), salt, length, iterations);

        public bool Authenticate(byte[] passwordInRepository, string passwordPassed, byte[] salt, int length, int iterations = 100)
        {
            var requestHash = GenerateHash(passwordPassed, salt, length, iterations);
            return requestHash.BytesEqual(passwordInRepository);
        }

        public async Task<(byte[], byte[])> GetHash(PasswordRequest passwordRequest, Organization organization)
        {
            var settings = organization.GetSettings(passwordRequest.SettingsName);
            var salt = RandomSalt(settings.SaltLength);
            return (GenerateHash(passwordRequest.Password, salt, settings.HashLength, settings.Iterations), salt);
        }
    }
}