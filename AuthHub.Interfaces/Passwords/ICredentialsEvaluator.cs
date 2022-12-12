using System;

namespace AuthHub.Interfaces.Passwords
{
    public interface ICredentialsEvaluator
    {
        Task<bool> EvaluateApiKeyAndSecret(Guid organizationId, string apiKey, string apiSecret);
        Task<(bool, Guid)> EvaluateUsernameAndPassword(Guid authSettingsId, string username, string password);
    }
}
