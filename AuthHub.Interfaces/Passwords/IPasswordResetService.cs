using System;

namespace AuthHub.Interfaces.Passwords;

public interface IPasswordResetService
{
    Task RequestPasswordResetForUser(Guid userId);
}