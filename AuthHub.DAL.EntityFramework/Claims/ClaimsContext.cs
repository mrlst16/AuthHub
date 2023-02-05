using AuthHub.Interfaces.Claims;
using AuthHub.Models.Entities.Passwords;
using AuthHub.Models.Entities.Users;
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

        public async Task SetClaims(Guid userId, IDictionary<string, string> claims)
        {
            var user = await _context.Users
                .Include(x => x.Password)
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

            //Step 1
            var existingKeys = user.Password.Claims
                .Where(x => x.DeletedUTC == null)
                .Select(x => x.Key);


            //Step 2
            var keysToDelete = existingKeys.Where(x => !claims.Keys.Contains(x));
            foreach (var claimsEntity in user.Password.Claims.Where(x => keysToDelete.Contains(x.Key)))
            {
                claimsEntity.DeletedUTC = _dateProvider.UTCNow;
            }

            //Step 3
            var keysToAdd = claims.Keys.Where(x => !existingKeys.Contains(x));

            //Here are all of the available 
            var keys = user.AuthSettings.AvailableClaimsKeys.Where(x => claims.Keys.Contains(x.Name));

            var newClaims = keys
                .Where(x => keysToAdd.Contains(x.Name))
                .Select(x => new ClaimsEntity()
                {
                    Id = Guid.NewGuid(),
                    Key = x.Name,
                    Value = claims.First(y => y.Key == x.Name).Value,
                    ClaimsKeyId = x.Id,
                    PasswordId = user.Password.Id
                });

            user.Password.Claims.AddRange(newClaims);

            _context.Users.Update(user);
            _context.SaveChanges(false);
        }
    }
}
