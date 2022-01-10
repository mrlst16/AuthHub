using AuthHub.Common.Extensions;
using AuthHub.Interfaces.Organizations;
using AuthHub.Interfaces.Passwords;
using AuthHub.Interfaces.Tokens;
using AuthHub.Models.Organizations;
using AuthHub.Models.Passwords;
using AuthHub.Models.Tokens;
using CommonCore2.Extensions;
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

        public JWTTokenGenerator(
            IOrganizationLoader organizationLoader,
            IPasswordLoader passwordLoader
            )
        {
            _organizationLoader = organizationLoader;
            _passwordLoader = passwordLoader;
        }

        public async Task<Token> GetToken(PasswordRequest request, Organization organization, bool forAudderClients = false)
        {
            try
            {
                var passwordRecord = await _passwordLoader.Get(request.OrganizationID, request.SettingsName, request.UserName);
                var authSettings = await _organizationLoader.GetSettings(request.OrganizationID, request.SettingsName);

                if (!Authenticate(request, passwordRecord))
                    throw new Exception($"Username and Password are not a match for user {request.UserName} in organization {organization.ID}");

                if (passwordRecord.Claims == null)
                    passwordRecord.Claims = new List<SerializableClaim>();
                if (passwordRecord.Claims.FirstOrDefault(x => x.Key == ClaimTypes.Name) == null)
                    passwordRecord.Claims.Add(new SerializableClaim(ClaimTypes.Name, passwordRecord.UserName));

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

                var orgId = organization.ID;
                if (forAudderClients)
                {
                    var userOrg = await _organizationLoader.Get(passwordRecord.UserName);
                    orgId = userOrg.ID;
                }

                var val = new JwtSecurityTokenHandler().WriteToken(token);
                return new Token(val, token.ValidTo, orgId);
            }
            catch (Exception e)
            {
                throw;
            }
            return null;
        }

        private byte[] GenerateSalt(int length)
        {
            byte[] result = new byte[length];

            using (var rng = new RNGCryptoServiceProvider())
            {
                rng.GetBytes(result);
            }
            return result;
        }

        private byte[] GenerateHash(byte[] password, byte[] salt, int length, int iterations = 100)
        {
            byte[] result = new byte[length];

            using (var derviedBytes = new Rfc2898DeriveBytes(password, salt, iterations))
            {
                result = derviedBytes.GetBytes(length);
            }

            return result;
        }

        private byte[] GenerateHash(string password, byte[] salt, int length, int iterations = 100)
            => GenerateHash(UTF8Encoding.UTF8.GetBytes(password), salt, length, iterations);

        public bool Authenticate(PasswordRequest request, Password password)
        {
            var requestHash = GenerateHash(request.Password, password.Salt, password.HashLength, password.Iterations);
            return requestHash.BytesEqual(password.PasswordHash);
        }

        public async Task<(byte[], byte[])> GetHash(PasswordRequest passwordRequest, Organization organization)
        {
            var settings = organization.GetSettings(passwordRequest.SettingsName);
            var salt = GenerateSalt(settings.SaltLength);
            return (GenerateHash(passwordRequest.Password, salt, settings.HashLength, settings.Iterations), salt);
        }
    }
}