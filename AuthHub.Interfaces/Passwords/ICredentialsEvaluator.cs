using System;

namespace AuthHub.Interfaces.Passwords
{
    public interface ICredentialsEvaluator
    {
        Task<bool> EvaluateApiKeyAndSecret(int organizationId, string apiKey, string apiSecret);
        Task<(bool, int)> EvaluateUsernameAndPassword(int authSettingsId, string username, string password);
    }
}
