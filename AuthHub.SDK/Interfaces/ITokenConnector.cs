using AuthHub.Models.Tokens;
using Common.Models.Responses;

namespace AuthHub.SDK.Interfaces
{
    public interface ITokenConnector
    {
        Task<ApiResponse<Token>> GetTokenAsync(string username, string password);
        Task<ApiResponse<Token>> RefreshTokenAsync(int userId, string refreshToken);
        Task<ApiResponse<Token>> GetUserTokenPhoneLogin(string phoneNumber, string verificationCode);
    }
}
