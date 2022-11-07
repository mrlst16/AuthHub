using AuthHub.Models.Passwords;
using AuthHub.Models.QueryResultSets;
using AuthHub.Models.Requests;
using AuthHub.Models.Users;
using System;

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

        /// <summary>
        /// Based on the userid, this method will get data to used to assemble a token
        /// </summary>
        /// <param name="userId"></param>
        /// <returns>TokenAssemblyData object used to construct a token</returns>
        Task<TokenAssemblyData> GetTokenAssemblyData(Guid authSettingsId, Guid userId);
    }
}