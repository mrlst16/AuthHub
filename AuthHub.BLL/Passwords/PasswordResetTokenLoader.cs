﻿using AuthHub.Interfaces.Passwords;
using AuthHub.Models.Entities.Passwords;
using Common.Interfaces.Repository;
using System;
using System.Linq;
using System.Threading.Tasks;

namespace AuthHub.BLL.Passwords
{
    public class PasswordResetTokenLoader : IPasswordResetTokenLoader
    {

        public PasswordResetTokenLoader(
            ISRDRepository<PasswordResetToken, Guid> passwordResetTokenRepo
            )
        {
            _passwordResetTokenRepo = passwordResetTokenRepo;
        }

        public async Task<Guid> SaveAsync(PasswordResetToken token)
            => await _passwordResetTokenRepo.SaveAsync(token);

        public async Task<PasswordResetToken> GetByVerificationCode(string verificationCode)
        {
            throw new NotImplementedException();
        }
    }
}
