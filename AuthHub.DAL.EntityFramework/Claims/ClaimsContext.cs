using AuthHub.Interfaces.Claims;
using AuthHub.Models.Entities.Claims;
using Common.Extensions;
using Common.Interfaces.Providers;
using Microsoft.EntityFrameworkCore;

namespace AuthHub.DAL.EntityFramework.Claims
{
    public class ClaimsContext : IClaimsContext
    {
        private readonly AuthHubContext _context;
        private readonly IDateProvider _dateProvider;

        public ClaimsContext(
            AuthHubContext context,
            IDateProvider dateProvider
            )
        {
            _context = context;
            _dateProvider = dateProvider;
        }

        public async Task<ClaimsTemplate> GetClaimsTemplateAsync(int organizationId, string name)
            => await _context.ClaimsTemplates
                .Include(x => x.ClaimsKeys)
                .FirstOrDefaultAsync(x=> x.OrganizationId == organizationId && x.Name == name);

        public async Task SetClaims(int userId, IDictionary<string, string> claims)
        {
            var user = await _context.Users
                .Include(x=> x.Claims)
                .Include(x => x.AuthSettings)
                .ThenInclude(x => x.AvailableClaimsKeys)
                .FirstOrDefaultAsync(x => x.Id == userId);

            if (user == null)
                throw new Exception("User not found");
            if (user.AuthSettings == null)
                throw new Exception("Auth Setting not found");
            if (user.AuthSettings.AvailableClaimsKeys == null || !user.AuthSettings.AvailableClaimsKeys.Any())
                throw new Exception("Not Claims Keys available");

            //Steps:
            //1.Pull Out the existing active keys
            //1.Mark the existing claims that aren't passed to the function as deleted
            //2.Add the claims that don't currently exist
            //note: Everything else leave alone

            //Here are all of the available keys
            var keys = user.AuthSettings.AvailableClaimsKeys.Where(x => claims.Keys.Contains(x.Name));
            var availableKeyNames = keys?.Select(x => x.Name) ?? new List<string>();

            if (claims.Keys.Any(x => !availableKeyNames.Contains(x)))
                throw new Exception("Some claims passed are not available");

            //Step 1
            var existingKeys = user.Claims
                .Where(x => x.DeletedUTC == null)
                .Select(x => x.Key);


            //Step 2
            var keysToDelete = existingKeys.Where(x => !claims.Keys.Contains(x));
            foreach (var claimsEntity in user.Claims.Where(x => keysToDelete.Contains(x.Key)))
            {
                claimsEntity.DeletedUTC = _dateProvider.UTCNow;
                _context.Claims.Update(claimsEntity);
            }

            //Step 3
            var keysToAdd = claims.Keys.Where(x => !existingKeys.Contains(x));

            var newClaims = keys
                .Where(x => keysToAdd.Contains(x.Name))
                .Select(x => new ClaimsEntity()
                {
                    Key = x.Name,
                    Value = claims.First(y => y.Key == x.Name).Value,
                    ClaimsKeyId = x.Id,
                });

            _context.Claims.AddRange(newClaims);
            _context.SaveChanges(false);
        }

        public async Task<int?> AddClaimsTemplateAsync(
            int organizationId,
            string name,
            string description, 
            IDictionary<string, string> keysAndDefaultValues
            )
        {
            if (_context.ClaimsTemplates.Contains(x => x.Name == name && x.OrganizationId == organizationId))
                throw new Exception($"Claims Template {name} already exists in organization with id of {organizationId}");

            ClaimsTemplate entity = new ClaimsTemplate()
            {
                OrganizationId = organizationId,
                Name = name,
                Description = description,
            };
            
            if (keysAndDefaultValues != null && keysAndDefaultValues.Any())
            {
                entity.ClaimsKeys = keysAndDefaultValues.Select(x => new ClaimsKey()
                {
                    Name = x.Key,
                    DefaultValue = x.Value
                }).ToList();
            }

            await _context.ClaimsTemplates.AddAsync(entity);
            await _context.SaveChangesAsync();
            return entity.Id;
        }

        public async Task<IEnumerable<ClaimsTemplate>> GetClaimsTemplateListAsync(int organizationId)
            => _context.ClaimsTemplates.Where(x => x.OrganizationId == organizationId);
    }
}