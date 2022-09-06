using AuthHub.BLL.Common.Exceptions;
using AuthHub.Interfaces.AuthSetting;
using AuthHub.Interfaces.Emails;
using AuthHub.Interfaces.Passwords;
using AuthHub.Interfaces.Users;
using AuthHub.Models.Passwords;
using AuthHub.Models.Requests;
using AuthHub.Models.Users;
using Common.Helpers;
using System;
using System.Threading.Tasks;
using Common.Interfaces.Providers;

namespace AuthHub.BLL.Passwords
{
    public class PasswordResetService : IPasswordResetService
    {
        private readonly IUserLoader _userLoader;
        private readonly IAuthHubEmailLoader _authHubEmailLoader;
        private readonly IAuthSettingsLoader _authSettingsLoader;
        private readonly IDateProvider _dateProvider;
        private readonly IPasswordResetTokenLoader _loader;

        public PasswordResetService(
            IUserLoader userLoader,
            IAuthHubEmailLoader authHubEmailLoader,
            IAuthSettingsLoader authSettingsLoader,
            IDateProvider dateProvider,
            IPasswordResetTokenLoader loader
        )
        {
            _userLoader = userLoader;
            _authHubEmailLoader = authHubEmailLoader;
            _authSettingsLoader = authSettingsLoader;
            _dateProvider = dateProvider;
            _loader = loader;
        }

        public async Task RequestPasswordResetForUser(Guid userId)
        {
            var user = await _userLoader.GetAsync(userId);
            if (user == null) throw new UserNotFoundException(userId);

            var authSettings = await _authSettingsLoader.ReadAsync(user.AuthSettingsId);

            var token = new PasswordResetToken()
            {
                UserId = user.Id,
                Email = user.Email,
                ExpirationDate = _dateProvider.UTCNow.AddMinutes(authSettings.PasswordResetTokenExpirationMinutes),
                VerificationCode = StringHelper.RandomAlphanumericString(6)
            };

            await _loader.SaveAsync(token);
            await _authHubEmailLoader.SendPasswordResetEmail(token);
        }


        public async Task RequestOrganizationPasswordReset(UserPointer userPointer)
        {
        }


        public async Task ResetOrganizationPassword(SetPasswordRequest request)
        {
        }

    }
}
