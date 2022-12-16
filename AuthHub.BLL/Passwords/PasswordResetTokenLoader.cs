using AuthHub.Interfaces.Passwords;
using Common.Interfaces.Repository;
using System;
using System.Linq;
using System.Threading.Tasks;
using AuthHub.Models.Entities.Passwords;

namespace AuthHub.BLL.Passwords
{
    public class PasswordResetTokenLoader : IPasswordResetTokenLoader
    {
        private readonly ISRDRepository<PasswordResetToken, Guid> _passwordResetTokenRepo;

        public PasswordResetTokenLoader(
            ISRDRepository<PasswordResetToken, Guid> passwordResetTokenRepo
            )
        {
            _passwordResetTokenRepo = passwordResetTokenRepo;
        }

        public async Task<Guid> SaveAsync(PasswordResetToken token)
            => await _passwordResetTokenRepo.SaveAsync(token);

        public async Task<PasswordResetToken> LookupByVerificationCode(string verificationCode)
            => (await _passwordResetTokenRepo.ReadAsync(x => x.VerificationCode == verificationCode))
                .FirstOrDefault();
    }
}
