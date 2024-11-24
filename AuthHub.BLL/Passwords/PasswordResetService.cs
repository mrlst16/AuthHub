using AuthHub.Interfaces.Emails;
using AuthHub.Interfaces.Passwords;
using AuthHub.Interfaces.Users;
using AuthHub.Models.Entities.Passwords;
using AuthHub.Models.Entities.Users;
using AuthHub.Models.Requests;
using Common.Helpers;
using Common.Interfaces.Providers;
using System;
using System.Threading.Tasks;
using AuthHub.Interfaces.AuthSetting;
using AuthHub.Interfaces.Hashing;
using AuthHub.Models.Entities.Organizations;
using Microsoft.Extensions.Configuration;

namespace AuthHub.BLL.Passwords
{
    public class PasswordResetService : IPasswordResetService
    {
        private readonly IUserLoader _userLoader;
        private readonly IAuthHubEmailService _authHubEmailLoader;
        private readonly IDateProvider _dateProvider;
        private readonly IAuthSettingsContext _authSettingsContext;
        private readonly IConfiguration _configuration;
        private readonly IHasher _hasher;
        private readonly IPasswordContext _passwordContext;

        public PasswordResetService(
            IUserLoader userLoader,
            IAuthHubEmailService authHubEmailLoader,
            IAuthSettingsContext authSettingsContext,
            IDateProvider dateProvider,
            IConfiguration configuration,
            IHasher hasher,
            IPasswordContext passwordContext
        )
        {
            _userLoader = userLoader;
            _authHubEmailLoader = authHubEmailLoader;
            _authSettingsContext = authSettingsContext;
            _dateProvider = dateProvider;
            _configuration = configuration;
            _hasher = hasher;
            _passwordContext = passwordContext;
        }

        public async Task<PasswordResetToken> RequestPasswordResetForUser(string username)
        {
            User user = await _userLoader.GetAsync(username);
            if (user == null) throw new Exception($"User {username} not found");

            var authSettings = await _authSettingsContext.GetAuthSettingsAsync(user.OrganizationId);

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
                var passwordResetUrl = authSettings.PasswordResetUrl ?? _configuration.GetValue<string>("AppSettings:PasswordResetUrl");
                await _authHubEmailLoader.SendPasswordResetEmail(token.Email, user.Id, passwordResetUrl, token.VerificationCode);
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
            AuthSettings settings = await _authSettingsContext.GetAuthSettingsAsync(user.OrganizationId);

            (var passwordHash, var salt) = _hasher.HashPasswordWithSalt(
                request.Password,
                settings.HashLength,
                settings.SaltLength,
                settings.Iterations
            );

            await _passwordContext.SaveAsync(request.UserId, passwordHash, salt);
        }
    }
}
