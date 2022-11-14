using AuthHub.Interfaces.Verification;
using AuthHub.Models.Enums;
using AuthHub.Models.Verification;

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

        public async Task Save(VerificationCode source)
        {
            await _context.VerificationCodes.AddAsync(source);
            await _context.SaveChangesAsync();
        }

        public async Task<VerificationCode> GetLatestByUserIdAndType(Guid userid, VerificationTypeEnum type)
        => _context.VerificationCodes
                .Where(x => x.User.Id == userid && x.Type == type)
                .OrderByDescending(x => x.ExpirationDate)
                .FirstOrDefault();
    }
}
