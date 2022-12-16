using System;
using AuthHub.Models.Entities.Users;

namespace AuthHub.Interfaces.Users
{
    public interface IUserContext
    {
        Task<User> Create(User user);
        Task<User> GetAsync(Guid id);
        Task<Guid> SaveAsync(User item);
        Task<User> Get(string userName);
    }
}
