using AuthHub.Models.Entities.Passwords;
using AuthHub.Models.Entities.Tokens;
using AuthHub.Models.Entities.Users;
using System;

namespace AuthHub.Interfaces.Users
{
    public interface IUserContext
    {
        Task<User> Create(User user);
        Task<User> GetAsync(Guid id);
        Task<Guid> SaveAsync(User item);
        Task<User> Get(string userName);
        Task AddToken(User user, Token token);
        Task UpdatePassword(User user, Password password, PasswordArchive archives);
        Task Update(User user);
    }
}
