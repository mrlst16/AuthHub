using AuthHub.Interfaces.Organizations;
using AuthHub.Interfaces.Passwords;
using AuthHub.Interfaces.Users;
using AuthHub.Models.Passwords;
using AuthHub.Models.Users;
using CommonCore.Models.Exceptions;
using System;
using System.Text;
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
                UserId = user.ID,
                Email = user.Email,
                ExpirationDate = DateTime.UtcNow.AddMinutes(authSettings.PasswordResetTokenExpirationMinutes),
                Token = RandomAlphanumericString(6)
            };
            await _passwordContext.SavePasswordResetToken(result);
            return (result);
        }

        private string RandomAlphanumericString(int length)
        {
            Random rand = new Random(Guid.NewGuid().GetHashCode());
            StringBuilder builder = new StringBuilder();

            for (int i = 0; i < length; i++)
            {
                int randNumber = rand.Next(48, 90);
                char c = (char)randNumber;
                builder.Append(c);
            }
            return builder.ToString();
        }

        public async Task<Password> GetByUserIdAsync(Guid userId)
            => await _passwordContext.GetByUserIdAsync(userId);

        public async Task Set(Password request)
            => await _passwordContext.Set(request);

        public async Task<LoginChallengeResponse> GetLoginChallenge(Guid authSettingsId, string userName)
            => await _passwordContext.GetLoginChallenge(authSettingsId, userName);  
    }
}
