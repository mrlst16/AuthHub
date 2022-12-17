using AuthHub.Models.Entities.Users;
using AuthHub.Models.Requests;
using System;

namespace AuthHub.Interfaces.Users
{
    public interface IUserService
    {
        Task<Guid> CreateAsync(CreateUserRequest request);
        Task<User> ReadAsync(Guid id);
    }
}
