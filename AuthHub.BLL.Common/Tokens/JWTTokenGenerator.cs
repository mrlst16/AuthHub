using AuthHub.BLL.Common.Extensions;
using AuthHub.Interfaces.Organizations;
using AuthHub.Interfaces.Passwords;
using AuthHub.Interfaces.Tokens;
using AuthHub.Interfaces.Users;
using AuthHub.Models.Organizations;
using AuthHub.Models.Passwords;
using AuthHub.Models.Requests;
using AuthHub.Models.Tokens;
using Common.Extensions;
using Common.Interfaces.Helpers;
using Common.Interfaces.Providers;
using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Security.Cryptography;

namespace AuthHub.BLL.Common.Tokens
{
    public class JWTTokenGenerator : ITokenGenerator
    {
        private readonly IOrganizationLoader _organizationLoader;
        private readonly IPasswordLoader _passwordLoader;
        private readonly IUserLoader _userLoader;
        private readonly IConfiguration _configuration;
        private readonly IApplicationConsistency _applicationConsistency;
        private readonly IDateProvider _dateProvider;

        public JWTTokenGenerator(
            IOrganizationLoader organizationLoader,
            IPasswordLoader passwordLoader,
            IUserLoader userLoader,
            IConfiguration configuration,
            IApplicationConsistency applicationConsistency,
            IDateProvider dateProvider
            )
        {
            _organizationLoader = organizationLoader;
            _passwordLoader = passwordLoader;
            _userLoader = userLoader;
            _configuration = configuration;
            _applicationConsistency = applicationConsistency;
            _dateProvider = dateProvider;
        }

        public async Task<bool> Authenticate(string username, string password, Guid authSettingsId)
        {
            var loginChallenge = await _passwordLoader.GetLoginChallenge(authSettingsId, username);
            return loginChallenge == null
                ? false
                : Authenticate(loginChallenge.StoredPasswordHash, password, loginChallenge.Salt, loginChallenge.Length, loginChallenge.Iterations);
        }

        public async Task<Token> GetTokenForAudderClients(string userName, string password)
            => await GetToken(_configuration.AuthHubOrganizationId(), userName, password);

        private byte[] RandomSalt(int length)
        {
            byte[] result = new byte[length];

            using var rng = new RNGCryptoServiceProvider();
            rng.GetBytes(result);
            return result;
        }

        public byte[] GenerateHash(byte[] password, byte[] salt, int length, int iterations = 100)
        {
            byte[] result = new byte[length];

            using var derivedBytes = new Rfc2898DeriveBytes(password, salt, iterations);
            result = derivedBytes.GetBytes(length);

            return result;
        }

        public byte[] GenerateHash(string password, byte[] salt, int length, int iterations = 100)
            => GenerateHash(_applicationConsistency.GetBytes(password), salt, length, iterations);

        public bool Authenticate(byte[] passwordInRepository, string passwordPassed, byte[] salt, int length, int iterations = 100)
        {
            var requestHash = GenerateHash(passwordPassed, salt, length, iterations);
            return requestHash.BytesEqual(passwordInRepository);
        }

        public async Task<(byte[], byte[])> NewHash(PasswordRequest passwordRequest, Organization organization)
        {
            var settings = organization.GetSettings(passwordRequest.SettingsName);
            var salt = RandomSalt(settings.SaltLength);
            return (GenerateHash(passwordRequest.Password, salt, settings.HashLength, settings.Iterations), salt);
        }

        public async Task<(byte[], byte[], IEnumerable<ClaimsKey>)> NewHash(string password, AuthSettings authSettings)
        {
            var salt = RandomSalt(authSettings.SaltLength);
            return (GenerateHash(password, salt, authSettings.HashLength, authSettings.Iterations), salt, authSettings.AvailableClaimsKeys);
        }

        public async Task<(byte[], byte[], IEnumerable<ClaimsKey>)> NewHash(string password, Guid authSettingsId)
        {
            var settings = await _organizationLoader.GetSettings(authSettingsId);
            var salt = RandomSalt(settings.SaltLength);
            return (GenerateHash(password, salt, settings.HashLength, settings.Iterations), salt, settings.AvailableClaimsKeys);
        }

        public async Task<Token> GetToken(Guid authSettingsId, string userName, string password)
        {
            var loginChallenge = await _passwordLoader.GetLoginChallenge(authSettingsId, userName);

            if (!Authenticate
                    (
                        loginChallenge.StoredPasswordHash,
                        password,
                        loginChallenge.Salt,
                        loginChallenge.Length,
                        loginChallenge.Iterations
                        )
                    )
                throw new Exception($"Username and Password are not a match for user {userName} while logging in as an ogranization");

            var user = await _userLoader.Get(authSettingsId, userName);
            var passwordRecord = user.Password;
            var authSettings = await _organizationLoader.GetSettings(authSettingsId);

            passwordRecord.Claims ??= new List<ClaimsEntity>();

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
                expires: passwordRecord.ExpirationDate,
                signingCredentials: credentials
            );

            var val = new JwtSecurityTokenHandler().WriteToken(token);
            return new Token(val, token.ValidTo, user.UsersOrganizationId);
        }
    }
}