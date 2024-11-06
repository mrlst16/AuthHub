using AuthHub.Models.Entities.Users;
using AuthHub.Models.Requests;
using System;
using AuthHub.Models.Responses.User;

namespace AuthHub.Interfaces.Users
{
    public interface IUserService
    {
        Task<User> CreateAsync(int organizationId, CreateUserRequest item);
        Task<UserResponse> ReadAsync(int id);
        Task SendEmailVerificationEmail(int userid);
    }
}
