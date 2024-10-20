using AuthHub.Models.Entities.Passwords;
using AuthHub.Models.Entities.Tokens;
using AuthHub.Models.Entities.Users;
using System;

namespace AuthHub.Interfaces.Users
{
    public interface IUserLoader
    {
        Task<User> Create(User user);
        Task<User> GetAsync(int id, bool requireVerification = true);
        Task<User> GetAsync(string username);
        Task<User> GetByPhoneNumberAsync(string phoneNumber);
        Task<int> SaveAsync(User item);
        Task AddToken(User user, Token token);
        Task UpdatePassword(User user, Password password, PasswordArchive archives);
        Task Update(User user);

    }
}
