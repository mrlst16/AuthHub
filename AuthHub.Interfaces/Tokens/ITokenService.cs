using AuthHub.Models.Entities.Tokens;

namespace AuthHub.Interfaces.Tokens
{
    public interface ITokenService
    {
        Task<Token> GetAsync(int organizationId, string userName);
        Task<Token> GetByPhoneVerificationCodeAsync(string phoneNumber, string verificationCode);
        Task<Token> GetRefreshTokenAsync(int userId, string refreshToken);
    }
}
