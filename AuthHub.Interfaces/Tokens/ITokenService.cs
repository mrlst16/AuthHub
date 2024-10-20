using AuthHub.Models.Entities.Tokens;
using System;

namespace AuthHub.Interfaces.Tokens
{
    public interface ITokenService
    {
        Task<Token> GetAsync(int userId);
        Task<Token> GetByPhoneVerificationCode(string phoneNumber, string verificationCode);
        Task<Token> GetRefreshToken(int userId, string refreshToken);
    }
}
