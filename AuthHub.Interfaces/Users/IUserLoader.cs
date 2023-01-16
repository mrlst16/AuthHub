using AuthHub.Models.Entities.Users;
using System;
using AuthHub.Models.Entities.Passwords;
using AuthHub.Models.Entities.Tokens;

namespace AuthHub.Interfaces.Users
{
    public interface IUserLoader
    {
        Task<User> Create(User user);
        Task<User> GetAsync(Guid id);
        Task<User> GetAsync(string username);
        Task<Guid> SaveAsync(User item);
        Task AddToken(User user, Token token);
        Task UpdatePassword(User user, Password password, PasswordArchive archives);
        Task Update(User user);

    }
}
