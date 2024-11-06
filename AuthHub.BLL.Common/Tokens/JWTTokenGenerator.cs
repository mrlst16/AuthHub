using AuthHub.BLL.Common.Extensions;
using AuthHub.Interfaces.Organizations;
using AuthHub.Interfaces.Tokens;
using AuthHub.Models.Entities.Claims;
using AuthHub.Models.Entities.Organizations;
using AuthHub.Models.Requests;
using Common.Extensions;
using Common.Interfaces.Helpers;
using System.Security.Cryptography;

namespace AuthHub.BLL.Common.Tokens
{
    public class JWTTokenGenerator : ITokenGenerator
    {
        private readonly IApplicationConsistency _applicationConsistency;

        public JWTTokenGenerator(
            IOrganizationLoader organizationLoader,
            IApplicationConsistency applicationConsistency
            )
        {
            _applicationConsistency = applicationConsistency;
        }

        private byte[] RandomSalt(int length)
        {
            byte[] result = new byte[length];

            using var rng = new RNGCryptoServiceProvider();
            rng.GetBytes(result);
            return result;
        }

        private byte[] GenerateHash(byte[] password, byte[] salt, int length, int iterations = 100)
        {
            byte[] result = new byte[length];

            using var derivedBytes = new Rfc2898DeriveBytes(password, salt, iterations);
            result = derivedBytes.GetBytes(length);

            return result;
        }

        public byte[] GenerateHash(string password, byte[] salt, int length, int iterations = 100)
            => GenerateHash(_applicationConsistency.GetBytes(password), salt, length, iterations);

        /// <summary>
        /// Hashes password in repo param with salt passed, and hashes password passed with salt passed, then compares the two
        /// </summary>
        /// <param name="passwordInRepository"></param>
        /// <param name="passwordPassed"></param>
        /// <param name="salt"></param>
        /// <param name="length"></param>
        /// <param name="iterations"></param>
        /// <returns></returns>
        public bool Authenticate(byte[] passwordInRepository, string passwordPassed, byte[] salt, int length, int iterations = 100)
        {
            var repoHash = GenerateHash(passwordInRepository, salt, length, iterations);
            var requestHash = GenerateHash(passwordPassed, salt, length, iterations);
            return requestHash.BytesEqual(repoHash);
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
    }
}