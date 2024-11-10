using AuthHub.Interfaces.AuthSetting;
using AuthHub.Models.Entities.Organizations;
using AuthHub.Models.Requests.AuthSettings;
using Microsoft.EntityFrameworkCore;

namespace AuthHub.DAL.EntityFramework.AuthSetting
{
    public class AuthSettingsContext : IAuthSettingsContext
    {
        private readonly AuthHubContext _context;

        public AuthSettingsContext(
            AuthHubContext context
            )
        {
            _context = context;
        }

        public async Task<AuthSettings> GetAsync(int id)
            => await _context
                .AuthSettings
                .Include(x => x.AuthScheme)
                .SingleOrDefaultAsync(x => x.Id == id);

        public async Task<AuthSettings> GetAuthSettingsAsync(int organizationId)
            => await _context.AuthSettings
                .Include(x=> x.AuthScheme)
                .FirstOrDefaultAsync(x => x.OrganizationID == organizationId);

        public async Task<bool> SaveAuthSettings(int organizationId, AuthSettingsRequest request)
        {
            AuthSettings entity = await GetAsync(organizationId);
            if (entity == null) return false;

            entity.Key = request.Key;
            entity.Issuer = request.Issuer;
            entity.Audience = request.Audience;
            entity.ExpirationMinutes = request.ExpirationMinutes;
            entity.HashLength = request.HashLength;
            entity.SaltLength = request.SaltLength;

            await _context.SaveChangesAsync();

            return true;
        }
    }
}
