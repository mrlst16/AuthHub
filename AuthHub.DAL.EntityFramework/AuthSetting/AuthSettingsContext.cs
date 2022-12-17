using AuthHub.Interfaces.AuthSetting;
using AuthHub.Models.Entities.Organizations;
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

        public async Task<AuthSettings> GetAsync(Guid id)
            => await _context
                .AuthSettings
                .SingleOrDefaultAsync(x => x.Id == id);
    }
}
