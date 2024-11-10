using System;
using System.Threading.Tasks;
using AuthHub.BLL.Common.Extensions;
using AuthHub.Interfaces.APIKeys;
using AuthHub.Interfaces.Hashing;
using AuthHub.Models.Responses.ApiKeys;
using Common.Helpers;
using Common.Interfaces.Helpers;

namespace AuthHub.BLL.ApiKeys
{
    public class ApiKeyService : IAPIKeyService
    {
        private readonly IApiKeyContext _context;
        private readonly IHasher _hasher;
        private readonly IApplicationConsistency _applicationConsistency;

        public ApiKeyService(
            IApiKeyContext context,
            IHasher hasher,
            IApplicationConsistency applicationConsistency
            )
        {
            _context = context;
            _hasher = hasher;
            _applicationConsistency = applicationConsistency;
        }

        public async Task<ApiKeyResponse> GenerateApiKeyAndSecretAsync(int organizationId)
        {
            string key = StringHelper.RandomAlphanumericString(64);
            string secret = StringHelper.RandomAlphanumericString(64);

            byte[] keyAndSecretBytes = $"{key}:{secret}".GetBytes();

            (var hash, var salt) = _hasher.HashPasswordWithSalt(keyAndSecretBytes, 128, 10, 100);

            await _context.AddAndInvalidateOthersAsync(organizationId, hash, salt, 128, 100);

            return new ApiKeyResponse()
            {
                ApiKey = key,
                Secret = secret
            };
        }

        public (byte[], byte[]) GenerateApiKeyAndSecretHash(string key, string secret)
            => _hasher.HashPasswordWithSalt($"{key}:{secret}".GetBytes(), 128, 10, 100);
    }
}