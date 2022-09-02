using AuthHub.Models.Users;
using System;
using System.Threading.Tasks;

namespace AuthHub.Interfaces.Users
{
    public interface IUserContext
    {
        Task<User> Create(Guid organizationId, string authSettingsName, User user);
        Task<User> Get(Guid organizationId, string authSettingsName, string username);
        Task<User> Get(UserPointer userPointer);
        Task<User> Update(Guid organizationId, string authSettingsName, User user);
        Task<User> Update(UserPointer pointer, User user);
        Task<User> GetAsync(Guid id);
        Task<Guid> SaveAsync(User item);
        Task<User> Get(Guid authSettingsId, string userName);
    }
}
