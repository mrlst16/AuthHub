using AuthHub.Interfaces.Verification;
using AuthHub.Models.Entities.Verification;
using AuthHub.Models.Enums;
using Microsoft.EntityFrameworkCore;

namespace AuthHub.DAL.EntityFramework.Verification
{
    public class VerificationCodeContext : IVerificationCodeContext
    {
        private readonly AuthHubContext _context;

        public VerificationCodeContext(
            AuthHubContext context
            )
        {
            _context = context;
        }

        public async Task Create(VerificationCode source)
        {
            source.Type = _context.VerificationTypes.FirstOrDefault(x => x.Value == source.Type.Value);

            await _context.VerificationCodes.AddAsync(source);
            await _context.SaveChangesAsync();
        }

        public async Task Update(VerificationCode source)
        {
            var existing = _context.VerificationCodes.First(x => x.Id == source.Id);
            existing = source;
            await _context.SaveChangesAsync();
        }

        public async Task<VerificationCode> GetLatestByUserIdAndType(int userid, VerificationTypeEnum type)
        {
            var user = _context
                .Users
                .Include(x => x.VerificationCodes)
                .ThenInclude(x => x.Type)
                .FirstOrDefault(x => x.Id == userid && x.DeletedUTC == null);
            var result = user.VerificationCodes
                .OrderByDescending(x => x.CreateDate)
                .FirstOrDefault(x => x.Type.Value == type);

            return result;
        }
    }
}
