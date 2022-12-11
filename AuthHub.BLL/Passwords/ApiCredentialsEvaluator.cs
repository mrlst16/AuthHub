using System;
using System.Threading.Tasks;
using AuthHub.Interfaces.Organizations;
using AuthHub.Interfaces.Passwords;

namespace AuthHub.BLL.Passwords
{
    public class ApiCredentialsEvaluator : IApiCredentialsEvaluator
    {
        private readonly IOrganizationLoader _organizationLoader;
        private readonly IPasswordEvaluator _passwordEvaluator;

        public ApiCredentialsEvaluator(
            IOrganizationLoader organizationLoader,
            IPasswordEvaluator passwordEvaluator
            )
        {
            _organizationLoader = organizationLoader;
            _passwordEvaluator = passwordEvaluator;
        }

        public async Task<bool> Evaluate(Guid organizationId, string apiKey, string apiSecret)
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
    }
}