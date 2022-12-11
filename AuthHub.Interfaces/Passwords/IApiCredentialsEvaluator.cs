using System;

namespace AuthHub.Interfaces.Passwords
{
    public interface IApiCredentialsEvaluator
    {
        Task<bool> Evaluate(Guid organizationId, string apiKey, string apiSecret);
    }
}
