using AuthHub.Interfaces.APIKeys;
using AuthHub.Models.Entities.Organizations;
using Microsoft.EntityFrameworkCore;

namespace AuthHub.DAL.EntityFramework.ApiKeys
{
    public class ApiKeyContext : IApiKeyContext
    {
        private readonly AuthHubContext _context;

        public ApiKeyContext(
            AuthHubContext context
            )
        {
            _context = context;
        }

        public async Task AddAndInvalidateOthersAsync(
            int organizationId, 
            byte[] hash,
            byte[] salt,
            int length,
            int iterations
            )
        {
            var undeleted = _context.ApiKeyAndSecrets.Where(x => x.DeletedUTC == null);
            await undeleted.ForEachAsync(async x => x.DeletedUTC = DateTime.UtcNow);
            await _context.SaveChangesAsync();

            APIKeyAndSecretHash entity = new APIKeyAndSecretHash()
            {
                CreateDate = DateTime.UtcNow,
                Hash = hash,
                Salt = salt,
                Length = length,
                Iterations = iterations,
                OrganizationId = organizationId
            };
            await _context.AddAsync(entity);
            await _context.SaveChangesAsync();
        }

        public async Task<APIKeyAndSecretHash> GetOrganizationsCurrentApiKeyAndSecretHashAsync(int organizationId)
            => await _context.ApiKeyAndSecrets
                .OrderByDescending(x=> x.CreateDate)
                .FirstOrDefaultAsync(x => x.OrganizationId == organizationId);
    }
}
