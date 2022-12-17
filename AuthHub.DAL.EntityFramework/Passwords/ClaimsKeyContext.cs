using AuthHub.Interfaces.Passwords;
using AuthHub.Models.Entities.Passwords;
using Microsoft.EntityFrameworkCore;

namespace AuthHub.DAL.EntityFramework.Passwords
{
    public class ClaimsKeyContext : IClaimsKeyContext
    {
        private readonly AuthHubContext _authHubContext;

        public ClaimsKeyContext(
            AuthHubContext authHubContext
            )
        {
            _authHubContext = authHubContext;
        }

        public async Task SaveAsync(IEnumerable<ClaimsKey> item)
        {
            var ids = item.Select(x => x.Id);
            var existing = await _authHubContext.ClaimsKeys.Where(x => ids.Contains(x.Id)).ToListAsync();
            _authHubContext.ClaimsKeys.UpdateRange(item.Where(x => existing.Contains(x)));

            var nonExisting = await _authHubContext.ClaimsKeys.Where(x => !ids.Contains(x.Id)).ToListAsync();
            await _authHubContext.ClaimsKeys.AddRangeAsync(item.Where(x => nonExisting.Contains(x)));
        }

        public async Task<IEnumerable<ClaimsKey>> GetAsync(Guid authSettingsId)
            => _authHubContext.ClaimsKeys.Where(x => x.AuthSettingsId == authSettingsId);
    }
}
