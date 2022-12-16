using AuthHub.Models.Requests;
using System;
using AuthHub.Models.Entities.Users;

namespace AuthHub.Interfaces.Users
{
    public interface IUserService
    {
        Task<Guid> CreateAsync(CreateUserRequest request);
        Task<User> ReadAsync(Guid id);
    }
}
