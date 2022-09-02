using AuthHub.Models.Organizations;
using AuthHub.Models.Passwords;
using AuthHub.Models.Requests;
using AuthHub.Models.Tokens;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace AuthHub.Interfaces.Tokens
{
    public interface ITokenGenerator
    {
        Task<Token> GetToken(Guid authSettings, string userName, string password);
        Task<Token> GetTokenForAudderClients(string userName, string password);
        Task<(byte[], byte[])> NewHash(PasswordRequest passwordRequest, Organization organization);
        Task<(byte[], byte[], IEnumerable<ClaimsKey>)> NewHash(string password, AuthSettings authSettings);
        Task<(byte[], byte[], IEnumerable<ClaimsKey>)> NewHash(string password, Guid authSettingsId);
    }
}
