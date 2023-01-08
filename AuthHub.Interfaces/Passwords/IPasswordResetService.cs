using AuthHub.Models.Requests;
using System;

namespace AuthHub.Interfaces.Passwords;

public interface IPasswordResetService
{
    Task RequestPasswordResetForUser(Guid userId);
    Task ResetUserPassword(ResetPasswordRequest request);
}