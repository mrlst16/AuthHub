using AuthHub.Models.Entities.Passwords;
using System;

namespace AuthHub.Interfaces.Passwords
{
    public interface IPasswordResetTokenLoader
    {
        Task<int> SaveAsync(PasswordResetToken token);
        Task<PasswordResetToken> GetByVerificationCode(string verificationCode);
    }
}
