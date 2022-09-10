using AuthHub.Models.Passwords;
using AuthHub.Models.Requests;
using AuthHub.Models.Users;
using System;
using AuthHub.BLL.QueryResultSets;

namespace AuthHub.Interfaces.Passwords
{
    public interface IPasswordLoader
    {
        Task<(bool, Password)> Set(Guid organizationId, string authSettingsname, Password request);
        Task<Guid> Set(Password request);
        Task<Password> Get(Guid organizationId, string authSettingsname, string username);
        Task<PasswordResetToken> GenerateAndSavePasswordResetToken(UserPointer userPointer);
        Task AuthenticateAndUpdateToken(SetPasswordRequest request);
        Task<Password> GetByUserIdAsync(Guid userId);
        Task<LoginChallengeResponse> GetLoginChallenge(Guid authSettingsId, string userName);
        Task<LoginChallengeResponse> GetLoginChallenge(Guid userId);
        Task<TokenAssemblyData> GetTokenAssemblyData(Guid uthSettingsId);
    }
}