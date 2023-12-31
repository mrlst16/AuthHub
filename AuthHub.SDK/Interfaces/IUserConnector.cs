using AuthHub.Models.Entities.Users;
using AuthHub.Models.Responses;
using Common.Models.Responses;

namespace AuthHub.SDK.Interfaces
{
    public interface IUserConnector
    {
        Task<ApiResponse<UserIdResponse>> SignUpAsync(string email, string username, string password, string firstName, string lastName);
        Task<ApiResponse<bool>> VerifyUserEmail(Guid userId, string verificationCode);
        Task<ApiResponse<UserResponse>> GetUserAsync(Guid userId);
    }
}
