using AuthHub.Interfaces.Organizations;
using AuthHub.Interfaces.Passwords;
using System;
using System.Threading.Tasks;
using AuthHub.Interfaces.AuthSetting;
using AuthHub.Interfaces.Users;

namespace AuthHub.BLL.Passwords
{
    public class CredentialsEvaluator : ICredentialsEvaluator
    {
        private readonly IOrganizationLoader _organizationLoader;
        private readonly IAuthSettingsLoader _authSettingsLoader;
        private readonly IUserLoader _userLoader;
        private readonly IPasswordEvaluator _passwordEvaluator;

        public CredentialsEvaluator(
            IOrganizationLoader organizationLoader,
            IAuthSettingsLoader authSettingsLoader,
            IUserLoader userLoader,
            IPasswordEvaluator passwordEvaluator
            )
        {
            _organizationLoader = organizationLoader;
            _authSettingsLoader = authSettingsLoader;
            _userLoader = userLoader;
            _passwordEvaluator = passwordEvaluator;
        }

        public async Task<bool> EvaluateApiKeyAndSecret(Guid organizationId, string apiKey, string apiSecret)
        {
            var organization = await _organizationLoader.Get(organizationId);
            if (organization.APIKeyAndSecretHash == null)
                throw new Exception($"No Api Key and Secret is available for organization id {organizationId}");

            return _passwordEvaluator.EvaluateUsernameAndPasswordWithSalt(
                apiKey,
                apiSecret,
                organization.APIKeyAndSecretHash.Length,
                organization.APIKeyAndSecretHash.Iterations,
                organization.APIKeyAndSecretHash.Salt,
                organization.APIKeyAndSecretHash.Hash
                );
        }

        public async Task<(bool, Guid)> EvaluateUsernameAndPassword(Guid authSettingsId, string username, string password)
        {
            var user = await _userLoader.GetAsync(username);
            var authSettings = await _authSettingsLoader.ReadAsync(authSettingsId);

            if (user == null) return (false, user.Id);

            var authenticationResult =  _passwordEvaluator.EvaluateUsernameAndPasswordWithSalt(
                username,
                password,
                authSettings.HashLength,
                authSettings.Iterations,
                user.Password.Salt,
                user.Password.PasswordHash
            );
            return (authenticationResult, user.Id);
        }
    }
}