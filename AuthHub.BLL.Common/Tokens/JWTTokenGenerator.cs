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

        public async Task<bool> Authenticate(string username, string password, Guid authSettingsId)
        {
            var loginChallenge = await _passwordLoader.GetLoginChallenge(authSettingsId, username);
            if (loginChallenge == null) return false;

            return Authenticate(loginChallenge.StoredPasswordHash, password, loginChallenge.Salt, loginChallenge.Length, loginChallenge.Iterations);
        }

        public async Task<Token> GetTokenForAudderClients(Guid authSettingsId, string userName, string password)
        {
            var authSettings = await _organizationLoader.GetSettings(authSettingsId);
            var user = await _userLoader.Get(authSettingsId, userName);
            var passwordRecord = user.Password;

            if (!Authenticate
                    (
                        passwordRecord.PasswordHash,
                        password,
                        passwordRecord.Salt,
                        authSettings.HashLength,
                        authSettings.Iterations
                        )
                    )
                throw new Exception($"Username and Password are not a match for user {userName} while logging in as an ogranization");

            if (passwordRecord.Claims == null)
                passwordRecord.Claims = new List<ClaimsEntity>();
            if (
                passwordRecord.Claims
                    .FirstOrDefault(x => string.Equals(x.Key, ClaimTypes.Name, StringComparison.InvariantCultureIgnoreCase)
                        ) == null)
                passwordRecord.Claims.Add(_configuration.CreateClaimsEntity(ClaimTypes.Name, userName));

            passwordRecord.Claims = passwordRecord?.Claims?.Where(x => !string.IsNullOrWhiteSpace(x.Key)).ToList();

            var securityKey = new SymmetricSecurityKey(_applicationConsistency.GetBytes(authSettings.Key));
            var credentials = new SigningCredentials(securityKey, SecurityAlgorithms.HmacSha256);

            var token = new JwtSecurityToken(
                issuer: authSettings.Issuer,
                audience: authSettings.Issuer,
                claims: passwordRecord?.GetClaims() ?? new List<Claim>(),
                expires: DateTime.Now.AddMinutes(authSettings.ExpirationMinutes),
                signingCredentials: credentials
                );

            var val = new JwtSecurityTokenHandler().WriteToken(token);
            return new Token(val, token.ValidTo, user.UsersOrganizationId);
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

        public async Task<Token> GetToken(Guid authSettingsId, string userName, string password)
        {
            var authSettings = await _organizationLoader.GetSettings(authSettingsId);
            var user = await _userLoader.Get(authSettingsId, userName);
            var passwordRecord = user.Password;

            if (!Authenticate
                    (
                        passwordRecord.PasswordHash,
                        password,
                        passwordRecord.Salt,
                        authSettings.HashLength,
                        authSettings.Iterations
                        )
                    )
                throw new Exception($"Username and Password are not a match for user {userName} while logging in as an ogranization");

            if (passwordRecord.Claims == null)
                passwordRecord.Claims = new List<ClaimsEntity>();
            if (
                passwordRecord.Claims
                    .FirstOrDefault(x => string.Equals(x.Key, ClaimTypes.Name, StringComparison.InvariantCultureIgnoreCase)
                        ) == null)
                passwordRecord.Claims.Add(_configuration.CreateClaimsEntity(ClaimTypes.Name, userName));

            passwordRecord.Claims = passwordRecord?.Claims?.Where(x => !string.IsNullOrWhiteSpace(x.Key)).ToList();

            var securityKey = new SymmetricSecurityKey(_applicationConsistency.GetBytes(authSettings.Key));
            var credentials = new SigningCredentials(securityKey, SecurityAlgorithms.HmacSha256);

            var token = new JwtSecurityToken(
                issuer: authSettings.Issuer,
                audience: authSettings.Issuer,
                claims: passwordRecord?.GetClaims() ?? new List<Claim>(),
                expires: DateTime.Now.AddMinutes(authSettings.ExpirationMinutes),
                signingCredentials: credentials
                );

            var val = new JwtSecurityTokenHandler().WriteToken(token);
            return new Token(val, token.ValidTo, user.UsersOrganizationId);
        }
    }
}