using AuthHub.Models.Entities.Users;
using AuthHub.Models.Requests;
using System;
using AuthHub.Models.Responses;

namespace AuthHub.Interfaces.Users
{
    public interface IUserService
    {
        Task<User> CreateAsync(CreateUserRequest request);
        Task<UserResponse> ReadAsync(Guid id);
        Task SendEmailVerificationEmail(Guid userid);
    }
}
