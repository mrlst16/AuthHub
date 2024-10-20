using AuthHub.Models.Entities.Passwords;
using AuthHub.Models.Requests;
using System;

namespace AuthHub.Interfaces.Passwords;

public interface IPasswordResetService
{
    Task<PasswordResetToken> RequestPasswordResetForUser(int userId);
    Task ResetUserPassword(ResetPasswordRequest request);
}