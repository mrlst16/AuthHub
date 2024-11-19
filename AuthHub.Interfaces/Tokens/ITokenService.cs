using AuthHub.Models.Entities.Tokens;
using AuthHub.Models.Responses.Tokens;

namespace AuthHub.Interfaces.Tokens
{
    public interface ITokenService
    {
        Task<TokenResponse> GetAsync(int organizationId, string userName);
        Task<TokenResponse> GetByPhoneVerificationCodeAsync(string phoneNumber, string verificationCode);
        Task<TokenResponse> GetRefreshTokenAsync(int userId, string refreshToken);
    }
}
