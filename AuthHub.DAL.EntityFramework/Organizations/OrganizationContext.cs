using AuthHub.Interfaces.Organizations;
using AuthHub.Models.Organizations;
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
            =>
                await _context
                    .Set<Organization>()
                    .AddAsync(request);

        public async Task<Organization> Get(Guid id)
            => await _context.Organizations.FirstAsync(x => x.ID == id);

        public async Task<Organization> Get(string name)
            => await _context.Organizations.FirstAsync(x => x.Name == name);

        public async Task<IList<Organization>> GetAll()
            => _context.Organizations.ToList();

        public async Task<AuthSettings> GetSettings(Guid organizationId, string name)
            => (await _context.Organizations.FirstAsync(x => x.ID == organizationId))
                .Settings.First(x => x.Name == name);

        public async Task<(bool, Organization)> Update(Organization request)
        {
            _context.Organizations.Update(request);
            return (true, request);
        }

        public async Task<(bool, AuthSettings)> UpdateSettings(Guid organizationId, AuthSettings request)
        {
            _context.AuthSettings.Update(request);
            return (true, request);
        }

        public async Task<AuthSettings> GetSettings(Guid authSettingsId)
            => await _context.AuthSettings.FirstAsync(x => x.ID == authSettingsId);
    }
}
