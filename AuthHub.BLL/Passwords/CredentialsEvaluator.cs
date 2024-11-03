using AuthHub.Interfaces.AuthSetting;
using AuthHub.Interfaces.Organizations;
using AuthHub.Interfaces.Passwords;
using AuthHub.Interfaces.Users;
using System;
using System.Threading.Tasks;
using AuthHub.Interfaces.APIKeys;

namespace AuthHub.BLL.Passwords
{
    public class CredentialsEvaluator : ICredentialsEvaluator
    {
        private readonly IOrganizationLoader _organizationLoader;
        private readonly IAuthSettingsLoader _authSettingsLoader;
        private readonly IUserLoader _userLoader;
        private readonly IPasswordEvaluator _passwordEvaluator;
        private readonly IApiKeyContext _apiKeyContext;

        public CredentialsEvaluator(
            IOrganizationLoader organizationLoader,
            IAuthSettingsLoader authSettingsLoader,
            IUserLoader userLoader,
            IPasswordEvaluator passwordEvaluator,
            IApiKeyContext apiKeyContext
            )
        {
            _organizationLoader = organizationLoader;
            _authSettingsLoader = authSettingsLoader;
            _userLoader = userLoader;
            _passwordEvaluator = passwordEvaluator;
            _apiKeyContext = apiKeyContext;
        }

        public async Task<bool> EvaluateApiKeyAndSecret(int organizationId, string apiKey, string apiSecret)
        {
            var storedHash = await _apiKeyContext.GetOrganizationsCurrentApiKeyAndSecretHashAsync(organizationId); 
            if (storedHash == null)
                throw new Exception($"No Api Key and Secret is available for organization id {organizationId}");

            return _passwordEvaluator.EvaluateUsernameAndPasswordWithSalt(
                apiKey,
                apiSecret,
                storedHash.Length,
                storedHash.Iterations,
                storedHash.Salt,
                storedHash.Hash
                );
        }

        public async Task<(bool, int)> EvaluateUsernameAndPassword(int authSettingsId, string username, string password)
        {
            var user = await _userLoader.GetAsync(username);
            var authSettings = await _authSettingsLoader.ReadAsync(authSettingsId);

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