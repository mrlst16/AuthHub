using AuthHub.Models.Entities.Users;
using AuthHub.Models.Responses;

namespace AuthHub.SDK.Interfaces
{
    public interface IUserConnector
    {
        Task<UserResponse> SignUpAsync(string email, string username, string password, string firstName, string lastName);
        Task<bool> VerifyUserEmail(Guid userId, string verificationCode);
    }
}
