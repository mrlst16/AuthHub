using AuthHub.Interfaces.Passwords;
using AuthHub.Models.Passwords;
using AuthHub.Models.Requests;

namespace AuthHub.DAL.EntityFramework.Passwords
{
    public class PasswordsContext : IPasswordContext
    {
        private readonly AuthHubContext _authHubContext;

        public PasswordsContext(
            AuthHubContext authHubContext
            )
        {
            _authHubContext = authHubContext;
        }

        public Task<(bool, Password)> Set(Guid organizationId, string authSettingsname, Password request)
        {
            throw new NotImplementedException();
        }

        public Task<Password> Get(Guid organizationId, string authSettingsname, string username)
        {
            throw new NotImplementedException();
        }

        public Task<PasswordResetToken> GetPasswordResetToken(string email, Guid organizationId, string authSettingsName, DateTime expirationDate)
        {
            throw new NotImplementedException();
        }

        public Task<PasswordResetToken> GetPasswordResetToken(Guid userId)
        {
            throw new NotImplementedException();
        }

        public Task SavePasswordResetToken(PasswordResetToken token)
        {
            throw new NotImplementedException();
        }

        public Task<Password> GetByUserIdAsync(Guid userId)
        {
            throw new NotImplementedException();
        }

        public Task Set(Password request)
        {
            throw new NotImplementedException();
        }

        public Task<LoginChallengeResponse> GetLoginChallenge(Guid authSettingsId, string userName)
        {
            throw new NotImplementedException();
        }

        Task<Guid> IPasswordContext.Set(Password request)
        {
            throw new NotImplementedException();
        }
    }
}