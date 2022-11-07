using AuthHub.Models.Users;
using System;

namespace AuthHub.Interfaces.Users
{
    public interface IUserLoader
    {
        Task<User> Create(User user);
        Task<User> GetAsync(Guid id);
        Task<User> GetAsync(string username);
        Task<Guid> SaveAsync(User item);
    }
}
