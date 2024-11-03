using AuthHub.Models.Responses.ApiKeys;

namespace AuthHub.Interfaces.APIKeys
{
    public interface IAPIKeyService
    {
        Task<ApiKeyResponse> GenerateApiKeyAndSecretAsync(int organizationId);
    }
}
