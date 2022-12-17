using AuthHub.BLL.Common.Exceptions;
using AuthHub.Interfaces.AuthSetting;
using AuthHub.Interfaces.Emails;
using AuthHub.Interfaces.Passwords;
using AuthHub.Interfaces.Users;
using AuthHub.Models.Entities.Passwords;
using Common.Helpers;
using Common.Interfaces.Providers;
using System;
using System.Threading.Tasks;

namespace AuthHub.BLL.Passwords
{
    public class PasswordResetService : IPasswordResetService
    {
        private readonly IUserLoader _userLoader;
        private readonly IAuthHubEmailService _authHubEmailLoader;
        private readonly IAuthSettingsLoader _authSettingsLoader;
        private readonly IDateProvider _dateProvider;
        private readonly IPasswordResetTokenLoader _loader;

        public PasswordResetService(
            IUserLoader userLoader,
            IAuthHubEmailService authHubEmailLoader,
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

            var token = new PasswordResetToken()
            {
                UserId = user.Id,
                Email = user.Email,
                ExpirationDate = _dateProvider.UTCNow.AddMinutes(15),
                VerificationCode = StringHelper.RandomAlphanumericString(6)
            };

            await _loader.SaveAsync(token);
            await _authHubEmailLoader.SendPasswordResetEmail(token.Email, userId, token.VerificationCode);
        }
    }
}
