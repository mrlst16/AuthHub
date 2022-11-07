using AuthHub.Interfaces.Users;
using AuthHub.Models.Organizations;
using AuthHub.Models.Users;
using Microsoft.EntityFrameworkCore;

namespace AuthHub.DAL.EntityFramework.Users
{
    public class UserContext : IUserContext
    {
        private readonly AuthHubContext _context;

        public UserContext(
            AuthHubContext context
            )
        {
            _context = context;
        }

        public async Task<User> Create(User user)
        {
            await SaveAsync(user);
            return user;
        }

        public async Task<User> Get(Guid organizationId, string authSettingsName, string username)
            => _context
                .AuthSettings
                .First(x => x.OrganizationID == organizationId && x.Name == authSettingsName)
                .Users
                .First(x => x.UserName == username);

        public async Task<User> Get(UserPointer userPointer)
            => await Get(userPointer.OrganizationID, userPointer.AuthSettingsName, userPointer.UserName);

        public async Task<User> GetAsync(Guid id)
            => (await _context.Users.SingleOrDefaultAsync(x => x.Id == id))!;

        public async Task<Guid> SaveAsync(User item)
        {
            var existingItem = item.Id == Guid.Empty
                    ? null :
                            await _context
                                .Users
                                .Include(x => x.AuthSettings)
                                .SingleOrDefaultAsync(x => x.Id == item.Id);
            existingItem.AuthSettings ??= new List<AuthSettings>();

            //if (!existingItem?.AuthSettings?.Any() ?? false)
            //{
            //    var authSettings = await _context.AuthSettings.FirstAsync(x => x.Id == item.AuthSettingsId);
            //    existingItem.AuthSettings.Append(authSettings);
            //}
            Guid result;
            if (existingItem == null)
            {
                await _context.Users.AddAsync(item);
                result = item.Id;
            }
            else
            {
                _context.Users.Update(existingItem);
                result = existingItem.Id;
            }

            await _context.SaveChangesAsync();
            return result;
        }

        public async Task<User> Get(string userName)
        {
            User result = null;

            try
            {
                result = await _context.Users.FirstOrDefaultAsync(x => x.UserName == userName && x.DeletedUTC == null);

            }
            catch (Exception e)
            {

            }
            return result;
        }
    }
}
