using AuthHub.Models.Entities.Tokens;
using System;

namespace AuthHub.Interfaces.Tokens
{
    public interface ITokenService
    {
        Task<Token> GetAsync(Guid userId);
        Task<Token> GetByPhoneVerificationCode(string phoneNumber, string verificationCode);
        Task<Token> GetRefreshToken(Guid userId, string refreshToken);
    }
}
