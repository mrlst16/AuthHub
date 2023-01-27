using AuthHub.Models.Entities.Users;
using AuthHub.Models.Requests;
using System;

namespace AuthHub.Interfaces.Users
{
    public interface IUserService
    {
        Task<User> CreateAsync(CreateUserRequest request);
        Task<User> ReadAsync(Guid id);
        Task SendEmailVerificationEmail(Guid userid);
    }
}
