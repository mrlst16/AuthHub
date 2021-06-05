using AuthHub.Models.Users;
using System;
using System.Threading.Tasks;

namespace AuthHub.Interfaces.Users
{
    public interface IUserLoader
    {
        Task<User> Create(Guid organizationId, User user);
        Task<User> Get(Guid organizationId, string username);
        Task<User> Update(Guid organizationId, User user);
    }
}
