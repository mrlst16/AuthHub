using AuthHub.Interfaces.Organizations;
using AuthHub.Models.Entities.Organizations;
using AuthHub.Models.Entities.Tokens;
using Microsoft.EntityFrameworkCore;

namespace AuthHub.DAL.EntityFramework.Organizations
{
    public class OrganizationContext : IOrganizationContext
    {
        private readonly AuthHubContext _context;

        public OrganizationContext(
            AuthHubContext context
            )
        {
            _context = context;
        }

        public async Task Create(Organization request)
        {
            await _context
                .Set<Organization>()
                .AddAsync(request);
            await _context.SaveChangesAsync();
        }

        public async Task<Organization> Get(int id)
            => await _context.Organizations
                .Include(x => x.APIKeyAndSecretHash)
                .FirstAsync(x => x.Id == id);

        public async Task<Organization> Get(string name)
            => await _context.Organizations.FirstAsync(x => x.Name == name);

        public async Task<IList<Organization>> GetAll()
            => _context.Organizations.ToList();

        public async Task<AuthSettings> GetSettings(int organizationId, string name)
            => await _context.AuthSettings.FirstOrDefaultAsync(x=> x.OrganizationID == organizationId);

        public async Task<(bool, Organization)> Update(Organization request)
        {
            _context.Organizations.Update(request);
            return (true, request);
        }

        public async Task<(bool, AuthSettings)> UpdateSettings(int organizationId, AuthSettings request)
        {
            _context.AuthSettings.Update(request);
            return (true, request);
        }

        public async Task<AuthSettings> GetSettings(int authSettingsId)
            => await _context.AuthSettings.FirstAsync(x => x.Id == authSettingsId);

        public async Task<bool> OrganizationExistsAsync(string name)
        {
            string lowerCaseName = name;
            return await _context.Organizations.FirstOrDefaultAsync(
                x => x.Name.ToLower() == lowerCaseName
                ) != null;
        }

        public async Task SaveOrganizationToken(OrganizationToken token)
        {
            _context.OrganizationTokens
                .Attach(token);
        }
    }
}
