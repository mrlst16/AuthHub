using AuthHub.Interfaces.Passwords;
using AuthHub.Models.Passwords;
using AuthHub.Models.Users;

namespace AuthHub.DAL.Sql.Passwords
{
    public class PasswordsContext : IPasswordContext
    {
        public Task AuthenticateAndUpdateToken(ResetPasswordRequest request)
        {
            throw new NotImplementedException();
        }

        public Task<PasswordResetToken> GeneratePasswordResetToken(UserPointer userPointer)
        {
            throw new NotImplementedException();
        }

        public Task<Password> Get(Guid organizationId, string authSettingsname, string username)
        {
            throw new NotImplementedException();
        }

        public Task<(bool, Password)> Set(Guid organizationId, string authSettingsname, Password request)
        {
            throw new NotImplementedException();
        }
    }
}
