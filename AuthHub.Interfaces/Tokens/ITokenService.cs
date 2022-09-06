using AuthHub.Models.Tokens;
using System;

namespace AuthHub.Interfaces.Tokens
{
    public interface ITokenService
    {
        Task<Token> GetToken(Guid authSettings, string userName, string password);
        Task<Token> GetTokenForAudderClients(string userName, string password);
        Task<bool> Authenticate(string username, string password, Guid authSettingsId);
    }
}
