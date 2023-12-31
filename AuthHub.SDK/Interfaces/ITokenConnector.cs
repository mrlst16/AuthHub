using AuthHub.Models.Tokens;
using Common.Models.Responses;

namespace AuthHub.SDK.Interfaces
{
    public interface ITokenConnector
    {
        Task<ApiResponse<Token>> GetJWTTokenAsync(string username, string password);
        Task<ApiResponse<Token>> RefreshJWTTokenAsync(Guid userId, string refreshToken);
    }
}
