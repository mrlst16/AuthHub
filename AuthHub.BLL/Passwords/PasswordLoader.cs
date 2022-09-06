using AuthHub.Interfaces.Organizations;
using AuthHub.Interfaces.Passwords;
using AuthHub.Interfaces.Users;
using AuthHub.Models.Passwords;
using AuthHub.Models.Requests;
using AuthHub.Models.Users;
using Common.Helpers;
using Common.Models.Exceptions;
using System;
using System.Threading.Tasks;

namespace AuthHub.BLL.Passwords
{
    public class PasswordLoader : IPasswordLoader
    {
        private readonly IPasswordContext _passwordContext;
        private readonly IOrganizationContext _organizationContext;
        private readonly IUserContext _userContext;
        public PasswordLoader(
            IPasswordContext passwordContext,
            IOrganizationContext organizationContext,
            IUserContext userContext
            )
        {
            _passwordContext = passwordContext;
            _organizationContext = organizationContext;
            _userContext = userContext;
        }


        public async Task AuthenticateAndUpdateToken(SetPasswordRequest request)
        {
            var token = await _passwordContext.GetPasswordResetToken(request.UserId);

            if (token == null)
                throw new HttpException("Unable to authenticate reset password token", 403);

            if (!string.Equals(request.Token, token.Token, StringComparison.InvariantCulture))
                throw new HttpException("Unable to authenticate reset password token", 403);
        }

        public async Task<Password> Get(Guid organizationId, string authSettingsname, string username)
            => await _passwordContext.Get(organizationId, authSettingsname, username);

        public async Task<(bool, Password)> Set(Guid organizationId, string authSettingsname, Password request)
        {
            return await _passwordContext.Set(organizationId, authSettingsname, request);
        }

        public async Task<PasswordResetToken> GenerateAndSavePasswordResetToken(UserPointer userPointer)
        {
            var user = await _userContext.Get(userPointer);
            var authSettings = await _organizationContext.GetSettings(userPointer.OrganizationID, userPointer.UserName);

            var result = new PasswordResetToken()
            {
                UserId = user.Id,
                Email = user.Email,
                ExpirationDate = DateTime.UtcNow.AddMinutes(authSettings.PasswordResetTokenExpirationMinutes),
                Token = StringHelper.RandomAlphanumericString(6)
            };
            await _passwordContext.SavePasswordResetToken(result);
            return (result);
        }



        public async Task<Password> GetByUserIdAsync(Guid userId)
            => await _passwordContext.GetByUserIdAsync(userId);

        public async Task<Guid> Set(Password request)
            => await _passwordContext.Set(request);

        public async Task<LoginChallengeResponse> GetLoginChallenge(Guid authSettingsId, string userName)
            => await _passwordContext.GetLoginChallenge(authSettingsId, userName);

        public async Task<Password> Get(Guid authSettingsId, string username)
        {
            throw new NotImplementedException();
        }
    }
}
