using AuthHub.Models.Users;
using System;

namespace AuthHub.Interfaces.Users
{
    public interface IUserContext
    {
        Task<User> Create(User user);
        Task<User> Get(Guid organizationId, string authSettingsName, string username);
        Task<User> Get(UserPointer userPointer);
        Task<User> GetAsync(Guid id);
        Task<Guid> SaveAsync(User item);
        Task<User> Get(string userName);
    }
}
