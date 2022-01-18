using AuthHub.Models.Users;
using CommonCore.Interfaces.Repository;
using System;
using System.Threading.Tasks;

namespace AuthHub.Interfaces.Users
{
    public interface IUserLoader : ISR<User>
    {
        Task<User> Create(Guid organizationId, string authSettingsName, User user);
        Task<User> Get(Guid organizationId, string authSettingsName, string username);
        Task<User> Get(UserPointer userPointer);
        Task<User> Update(Guid organizationId, string authSettingsName, User user);
        Task<User> Update(UserPointer pointer, User user);
    }
}
