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

        public async Task<User> Create(User user)
        {
            await _context.Users.AddAsync(user);
            await _context.SaveChangesAsync();
            return user;
        }

        public async Task<User> GetAsync(Guid id)
            => (await _context
                .Users
                .Include(x => x.AuthSettings)
                .Include(x => x.Password)
                .ThenInclude(x => x.Claims)
                .SingleOrDefaultAsync(x => x.Id == id))!;

        public async Task<Guid> SaveAsync(User item)
        {
            var existingItem = item.Id == Guid.Empty
                    ? null :
                            await _context
                                .Users
                                .SingleOrDefaultAsync(x => x.Id == item.Id);
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

        public async Task<User?> Get(string userName)
        {
            try
            {
                var result = await _context
                    .Users
                    .Include(x => x.Password)
                    .FirstOrDefaultAsync(x => x.UserName == userName && x.DeletedUTC == null);
                return result;
            }
            catch (Exception e)
            {
                return null;
            }
        }
    }
}