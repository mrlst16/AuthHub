using AuthHub.Models.Tokens;
using System;

namespace AuthHub.Interfaces.Tokens
{
    public interface ITokenService
    {
        Task<Token> GetJWTUserToken(Guid userId);
    }
}
