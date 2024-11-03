using AuthHub.Models.Entities.Organizations;

namespace AuthHub.Interfaces.APIKeys
{
    public interface IApiKeyContext
    {
        Task AddAndInvalidateOthersAsync(
            int organizationId,
            byte[] hash,
            byte[] salt,
            int length,
            int iterations
        );

        Task<APIKeyAndSecretHash> GetOrganizationsCurrentApiKeyAndSecretHashAsync(int organizationId);
    }
}