using AuthHub.Interfaces.Users;
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

        public async Task<User> Create(Guid organizationId, string authSettingsName, User user)
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

        public async Task<User> Update(Guid organizationId, string authSettingsName, User user)
        {
            await SaveAsync(user);
            return user;
        }

        public async Task<User> Update(UserPointer pointer, User user)
            => await Update(pointer.OrganizationID, pointer.AuthSettingsName, user);

        public async Task<User> GetAsync(Guid id)
            => (await _context.Users.SingleOrDefaultAsync(x => x.Id == id))!;

        public async Task<Guid> SaveAsync(User item)
        {
            var existingItem = item.Id == Guid.Empty
                    ? null :
                            await _context.Users.SingleOrDefaultAsync(x => x.Id == item.Id);

            if (existingItem == null) await _context.Users.AddAsync(existingItem);
            else
            {
                _context.Users.Update(existingItem);
                return existingItem.Id;
            }

            await _context.SaveChangesAsync();
            return new Guid();
        }

        public async Task<User> Get(Guid authSettingsId, string userName)
            => (await _context
                .Users
                .SingleOrDefaultAsync(x => x.AuthSettingsId == authSettingsId && x.UserName == userName))!;
    }
}
