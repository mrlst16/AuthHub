using AuthHub.Models.Users;
using System;

namespace AuthHub.Interfaces.Users
{
    public interface IUserService
    {
        Task<Guid> CreateAsync(CreateUserRequest request);
        Task<User> ReadAsync(Guid id);
    }
}
