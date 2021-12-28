using AuthHub.Interfaces.Passwords;
using AuthHub.Models.Passwords;
using AuthHub.Models.Users;
using System;
using System.Threading.Tasks;

namespace AuthHub.BLL.Passwords
{
    public class PasswordLoader : IPasswordLoader
    {

        private readonly IPasswordContext _passwordContext;

        public PasswordLoader(
            IPasswordContext passwordContext
            )
        {
            _passwordContext = passwordContext;
        }

        public async Task AuthenticateAndUpdateToken(ResetPasswordRequest request)
            => await _passwordContext.AuthenticateAndUpdateToken(request);

        public async Task<PasswordResetToken> GeneratePasswordResetToken(UserPointer userPointer)
            => await _passwordContext.GeneratePasswordResetToken(userPointer);

        public async Task<Password> Get(Guid organizationId, string authSettingsname, string username)
            => await _passwordContext.Get(organizationId, authSettingsname, username);

        public async Task<(bool, Password)> Set(Guid organizationId, string authSettingsname, Password request)
            => await _passwordContext.Set(organizationId, authSettingsname, request);
    }
}
