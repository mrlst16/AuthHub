using AuthHub.Interfaces.AuthSetting;
using AuthHub.Interfaces.Organizations;
using AuthHub.Interfaces.Passwords;
using AuthHub.Interfaces.Users;
using System;
using System.Threading.Tasks;
using AuthHub.Interfaces.APIKeys;
using AuthHub.Interfaces.Hashing;
using Common.Interfaces.Helpers;

namespace AuthHub.BLL.Passwords
{
    public class CredentialsEvaluator : ICredentialsEvaluator
    {
        private readonly IAuthSettingsContext _authSettingsContext;
        private readonly IUserLoader _userLoader;
        private readonly IPasswordEvaluator _passwordEvaluator;
        private readonly IApiKeyContext _apiKeyContext;
        private readonly IApplicationConsistency _applicationConsistency;
        private readonly IHasher _hasher;

        public CredentialsEvaluator(
            IAuthSettingsContext authSettingsContext,
            IUserLoader userLoader,
            IPasswordEvaluator passwordEvaluator,
            IApiKeyContext apiKeyContext,
            IApplicationConsistency applicationConsistency,
            IHasher hasher
            )
        {
            _authSettingsContext = authSettingsContext;
            _userLoader = userLoader;
            _passwordEvaluator = passwordEvaluator;
            _apiKeyContext = apiKeyContext;
            _applicationConsistency = applicationConsistency;
            _hasher = hasher;
        }

        public async Task<bool> EvaluateApiKeyAndSecret(int organizationId, string apiKey, string apiSecret)
        {
            var apiKeyEntity = await _apiKeyContext.GetOrganizationsCurrentApiKeyAndSecretHashAsync(organizationId); 
            if (apiKeyEntity == null)
                throw new Exception($"No Api Key and Secret is available for organization id {organizationId}");

            byte[] calculatedHash = _hasher.HashPasswordWithSalt(
                $"{apiKey}:{apiSecret}", 
                apiKeyEntity.Salt,
                apiKeyEntity.Length,
                apiKeyEntity.Iterations);

            return _applicationConsistency.BytesEqual(apiKeyEntity.Hash, calculatedHash);
        }

        public async Task<(bool, int)> EvaluateUsernameAndPassword(int organizationId, string username, string password)
        {
            var user = await _userLoader.GetAsync(username);
            var authSettings = await _authSettingsContext.GetAuthSettingsAsync(organizationId);

            if (user == null)
                throw new Exception("Username was not found");

            var authenticationResult = _passwordEvaluator.EvaluateUsernameAndPasswordWithSalt(
                username,
                password,
                authSettings.HashLength,
                authSettings.Iterations,
                user.Password.Salt,
                user.Password.PasswordHash
            );
            if (!authenticationResult)
                throw new Exception("Invalid username and password combination.");
            return (authenticationResult, user.Id);
        }
    }
}