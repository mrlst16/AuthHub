using System;
using AuthHub.Models.Entities.Passwords;

namespace AuthHub.Interfaces.Passwords
{
    public interface IPasswordResetTokenLoader
    {
        Task<Guid> SaveAsync(PasswordResetToken token);
        Task<PasswordResetToken> LookupByVerificationCode(string verificationCode);
    }
}
