using AuthHub.Models.Requests;
using System;
using AuthHub.Models.Entities.Passwords;

namespace AuthHub.Interfaces.Passwords;

public interface IPasswordResetService
{
    Task<PasswordResetToken> RequestPasswordResetForUser(Guid userId);
    Task ResetUserPassword(ResetPasswordRequest request);
}