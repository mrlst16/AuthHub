using AuthHub.BLL.Common.Exceptions;
using AuthHub.Interfaces.Emails;
using AuthHub.Interfaces.Passwords;
using AuthHub.Interfaces.Tokens;
using AuthHub.Interfaces.Users;
using AuthHub.Models.Entities.Claims;
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
        private readonly IDateProvider _dateProvider;
        private readonly Func<AuthSchemeEnum, ITokenGenerator> _tokenGeneratorFactory;
        private readonly IAuthHubEmailService _emailService;

        public PasswordResetService(
            IUserLoader userLoader,
            IAuthHubEmailService authHubEmailLoader,
            IDateProvider dateProvider,
            Func<AuthSchemeEnum, ITokenGenerator> tokenGeneratorFactory,
            IAuthHubEmailService emailService
        )
        {
            _userLoader = userLoader;
            _authHubEmailLoader = authHubEmailLoader;
            _dateProvider = dateProvider;
            _tokenGeneratorFactory = tokenGeneratorFactory;
            _emailService = emailService;
        }

        public async Task<PasswordResetToken> RequestPasswordResetForUser(int userId)
        {
            User user = await _userLoader.GetAsync(userId);
            if (user == null) throw new UserNotFoundException(userId);

            var token = new PasswordResetToken()
            {
                UserId = user.Id,
                Email = user.Email,
                ExpirationDate = _dateProvider.UTCNow.AddMinutes(15),
                VerificationCode = StringHelper.RandomAlphanumericString(6)
            };

            user.PasswordResetTokens.Add(token);
            await _userLoader.SaveAsync(user);
            try
            {
                //await _authHubEmailLoader.SendPasswordResetEmail(token.Email, userId, user.AuthSettings.PasswordResetFormUrl, token.VerificationCode);
            }
            catch (Exception e)
            {
                //Swallow
            }
            return token;
        }

        public async Task ResetUserPassword(ResetPasswordRequest request)
        {
            User user = await _userLoader.GetAsync(request.UserId);
            ITokenGenerator tokenGenerator = _tokenGeneratorFactory(user.AuthSettings.AuthScheme);

            //TODO: this was gutted
        }
    }
}
