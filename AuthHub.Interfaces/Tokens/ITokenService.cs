using AuthHub.Models.Tokens;
using System;

namespace AuthHub.Interfaces.Tokens
{
    public interface ITokenService
    {
        Task<Token> GetToken(Guid authSettingsId, string userName, string password);
    }
}
