using AuthHub.Models.Passwords;
using AuthHub.Models.Requests;
using System;

namespace AuthHub.Interfaces.Passwords
{
    public interface IPasswordContext
    {
        Task<(bool, Password)> Set(Guid organizationId, string authSettingsname, Password request);
        Task<Password> Get(Guid organizationId, string authSettingsname, string username);
        Task<PasswordResetToken> GetPasswordResetToken(string email, Guid organizationId, string authSettingsName, DateTime expirationDate);
        Task<PasswordResetToken> GetPasswordResetToken(Guid userId);
        Task SavePasswordResetToken(PasswordResetToken token);
        Task<Password> GetByUserIdAsync(Guid userId);
        Task<Guid> Set(Password request);
        Task<LoginChallengeResponse> GetLoginChallenge(Guid authSettingsId, string userName);
    }
}