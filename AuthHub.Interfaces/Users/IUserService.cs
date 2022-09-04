using AuthHub.Models.Users;
using System;
using System.Threading.Tasks;

namespace AuthHub.Interfaces.Users
{
    public interface IUserService
    {
        Task CreateAsync(CreateUserRequest request);
        Task<User> ReadAsync(Guid id);
    }
}
