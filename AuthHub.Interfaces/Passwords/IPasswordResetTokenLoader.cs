using AuthHub.Models.Entities.Passwords;
using System;

namespace AuthHub.Interfaces.Passwords
{
    public interface IPasswordResetTokenLoader
    {
        Task<Guid> SaveAsync(PasswordResetToken token);
        Task<PasswordResetToken> LookupByVerificationCode(string verificationCode);
    }
}
