using AuthHub.Models.Entities.Passwords;
using System;

namespace AuthHub.Interfaces.Passwords
{
    public interface IPasswordContext
    {
        Task SaveAsync(int userId, byte[] passwordHash, byte[] salt);
    }
}