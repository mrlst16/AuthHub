using AuthHub.BLL.Common.Exceptions;
using AuthHub.Interfaces.AuthSetting;
using AuthHub.Interfaces.Emails;
using AuthHub.Interfaces.Passwords;
using AuthHub.Interfaces.Tokens;
using AuthHub.Interfaces.Users;
using AuthHub.Interfaces.Verification;
using AuthHub.Models.Entities.Passwords;
using AuthHub.Models.Entities.Users;
using AuthHub.Models.Enums;
using AuthHub.Models.Requests;
using Common.Helpers;
using Common.Interfaces.Providers;
using System;
using System.Collections.Generic;
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
        private readonly Func<AuthSchemeEnum, ITokenGenerator> _tokenGeneratorFactory;
        private readonly IVerificationCodeService _verificationCodeService;
        private readonly IAuthHubEmailService _emailService;

        public PasswordResetService(
            IUserLoader userLoader,
            IAuthHubEmailService authHubEmailLoader,
            IAuthSettingsLoader authSettingsLoader,
            IDateProvider dateProvider,
            IPasswordResetTokenLoader loader,
            Func<AuthSchemeEnum, ITokenGenerator> tokenGeneratorFactory,
            IVerificationCodeService verificationCodeService,
            IAuthHubEmailService emailService
        )
        {
            _userLoader = userLoader;
            _authHubEmailLoader = authHubEmailLoader;
            _authSettingsLoader = authSettingsLoader;
            _dateProvider = dateProvider;
            _loader = loader;
            _tokenGeneratorFactory = tokenGeneratorFactory;
            _verificationCodeService = verificationCodeService;
            _emailService = emailService;
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
            await _authHubEmailLoader.SendPasswordResetEmail(token.Email, userId, user.AuthSettings.PasswordResetFormUrl, token.VerificationCode);
        }

        public async Task ResetUserPassword(ResetPasswordRequest request)
        {
            User user = await _userLoader.GetAsync(request.UserId);
            Guid newPasswordId = Guid.NewGuid();
            ITokenGenerator tokenGenerator = _tokenGeneratorFactory(user.AuthSettings.AuthScheme);

            (byte[] passwordHash, byte[] salt, IEnumerable<ClaimsKey> claimsKeys)
                = await tokenGenerator.NewHash(request.NewPassword, user.AuthSettings);

            Password password = new()
            {
                Id = newPasswordId,
                UserId = user.Id,
                PasswordHash = passwordHash,
                Salt = salt,
                Claims = user.Password.Claims
            };

            user.PasswordArchives.Add(user.Password);
            user.Password = password;
            user.Id = await _userLoader.SaveAsync(user);
        }
    }
}
