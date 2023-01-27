using AuthHub.Interfaces.Users;
using AuthHub.Models.Entities.Passwords;
using AuthHub.Models.Entities.Tokens;
using AuthHub.Models.Entities.Users;
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
                .ThenInclude(x => x.AuthScheme)
                .Include(x => x.PasswordArchives)
                .Include(x => x.Password)
                .ThenInclude(x => x.Claims)
                .Include(x => x.Tokens)
                .Include(x => x.PasswordResetTokens)
                .Include(x=> x.VerificationCodes)
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

        public async Task AddToken(User user, Token token)
        {
            var existingItem =
                await _context
                    .Users
                    .Include(x => x.Tokens)
                    .SingleOrDefaultAsync(x => x.Id == user.Id);
            if (existingItem == null) return;
            _context.Tokens.Add(token);
            _context.Users.Update(existingItem);
            await _context.SaveChangesAsync();
        }

        public async Task UpdatePassword(User user, Password password, PasswordArchive archives)
        {
            //var existing = _context
            //    .Users
            //    .Include(x=> x.Password)
            //    .ThenInclude(x=> x.Claims)
            //    .Include(x=> x.PasswordArchives)
            //    .FirstOrDefault(x => x.Id == user.Id);
            //if (existing == null) throw new Exception("No user was found when updating password");

            //existing.Password = password;
            //existing.PasswordArchives.Add(archives);
            //_context.Users.Update(existing);
            //await _context.SaveChangesAsync();

            var exisitingPassword = _context.Passwords
                .Include(x => x.Claims)
                .FirstOrDefault(x => x.Id == password.Id);
            exisitingPassword = password;
            _context.Passwords.Update(exisitingPassword);
            await _context.SaveChangesAsync();
        }

        public async Task Update(User user)
        {
            _context.Users.Update(user);
            await _context.SaveChangesAsync();
        }

        public async Task AddPasswordArchive(User user, Password password)
        {

        }
    }
}