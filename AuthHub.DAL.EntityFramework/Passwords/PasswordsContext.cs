using AuthHub.Interfaces.Passwords;
using AuthHub.Models.Entities.Passwords;
using Microsoft.EntityFrameworkCore;

namespace AuthHub.DAL.EntityFramework.Passwords
{
    public class PasswordsContext : IPasswordContext
    {
        private readonly AuthHubContext _context;

        public PasswordsContext(
            AuthHubContext context
            )
        {
            _context = context;
        }

        public async Task SaveAsync(int userId, byte[] passwordHash, byte[] salt)
        {
            var entity = await _context.Passwords.FirstOrDefaultAsync(x => x.UserId == userId);
            _context.PasswordArchives.AddAsync(new PasswordArchive()
            {
                PasswordHash = entity.PasswordHash,
                Salt = entity.Salt,
                UserId = entity.UserId
            });
            entity.PasswordHash = passwordHash;
            entity.Salt = salt;
            entity.LastUpdated = DateTime.UtcNow;
            await _context.SaveChangesAsync();
        }
    }
}
