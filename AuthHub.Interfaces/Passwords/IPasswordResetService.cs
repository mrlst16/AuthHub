using AuthHub.Models.Requests;
using AuthHub.Models.Users;
using System;

namespace AuthHub.Interfaces.Passwords;

public interface IPasswordResetService
{
    Task RequestPasswordResetForUser(Guid userId);
    Task ResetOrganizationPassword(SetPasswordRequest request);
    Task RequestOrganizationPasswordReset(UserPointer userPointer);
}