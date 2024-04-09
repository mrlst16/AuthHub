using AuthHub.Models.Entities.Users;
using AuthHub.Models.Requests;
using AuthHub.Models.Responses.User;
using System;

namespace AuthHub.Interfaces.Users
{
    public interface IUserService
    {
        Task<User> CreateAsync(CreateUserRequest request);
        Task<UserResponse> ReadAsync(Guid id);
        Task SendEmailVerificationEmail(Guid userid);
    }
}
