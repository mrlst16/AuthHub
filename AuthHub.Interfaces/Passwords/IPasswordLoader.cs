using AuthHub.Models.Passwords;
using AuthHub.Models.Users;
using System;
using System.Threading.Tasks;

namespace AuthHub.Interfaces.Passwords
{
    public interface IPasswordLoader
    {
        Task<(bool, Password)> Set(Guid organizationId, string authSettingsname, Password request);
        Task Set(Password request);
        Task<Password> Get(Guid organizationId, string authSettingsname, string username);
        Task<PasswordResetToken> GenerateAndSavePasswordResetToken(UserPointer userPointer);
        Task AuthenticateAndUpdateToken(SetPasswordRequest request);
        Task<Password> GetByUserIdAsync(Guid userId);
        Task<LoginChallengeResponse> GetLoginChallenge(Guid authSettingsId, string userName); 
    }
}