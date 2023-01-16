using AuthHub.BLL.Common.Extensions;
using AuthHub.Interfaces.AuthSetting;
using AuthHub.Interfaces.Emails;
using AuthHub.Interfaces.Tokens;
using AuthHub.Interfaces.Users;
using AuthHub.Interfaces.Verification;
using AuthHub.Models.Entities.Passwords;
using AuthHub.Models.Entities.Users;
using AuthHub.Models.Entities.Verification;
using AuthHub.Models.Enums;
using AuthHub.Models.Requests;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AuthHub.BLL.Users
{
    public class UserService : IUserService
    {
        private readonly IUserLoader _loader;
        private readonly Func<AuthSchemeEnum, ITokenGenerator> _tokenGeneratorFactory;
        private readonly IConfiguration _configuration;
        private readonly IAuthSettingsLoader _authSettingsLoader;
        private readonly IAuthHubEmailService _emailService;
        private readonly IVerificationCodeService _verificationCodeService;

        public UserService(
            IConfiguration configuration,
            IUserLoader loader,
            Func<AuthSchemeEnum, ITokenGenerator> tokenGeneratorFactory,
            IAuthSettingsLoader authSettingsLoader,
            IAuthHubEmailService emailService,
            IVerificationCodeService verificationCodeService
            )
        {
            _loader = loader;
            _tokenGeneratorFactory = tokenGeneratorFactory;
            _configuration = configuration;
            _authSettingsLoader = authSettingsLoader;
            _emailService = emailService;
            _verificationCodeService = verificationCodeService;
        }

        public async Task<User> CreateAsync(CreateUserRequest item)
        {
            var authSettingsId = item.AuthSettingsID == Guid.Empty
                ? _configuration.AuthHubSettingsId()
                : item.AuthSettingsID;

            var authSettings = await _authSettingsLoader.ReadAsync(authSettingsId);
            var tokenGenerator = _tokenGeneratorFactory(authSettings.AuthScheme);

            (byte[] passwordHash, byte[] salt, IEnumerable<ClaimsKey> claimsKeys)
                = await tokenGenerator.NewHash(item.Password, authSettings);

            var newUserId = Guid.NewGuid();
            var newPasswordId = Guid.NewGuid();

            User user = new()
            {
                Id = newUserId,
                AuthSettings = authSettings,
                AuthSettingsId = authSettingsId,
                Email = item.Email,
                FirstName = item.FirstName,
                LastName = item.LastName,
                UserName = item.UserName,
                Password = new()
                {
                    Id = newPasswordId,
                    UserId = newUserId,
                    PasswordHash = passwordHash,
                    Salt = salt,
                    Claims = claimsKeys.Where(x => x.IsDefault)
                        .Select(x => new ClaimsEntity()
                        {
                            Id = Guid.NewGuid(),
                            Value = x.DefaultValue,
                            Key = x.Name,
                            ClaimsKeyId = x.Id,
                            PasswordId = newPasswordId
                        }).ToList()
                }
            };

            user.Id = await _loader.SaveAsync(user);
            try
            {
                VerificationCode code = await _verificationCodeService.GenerateAndSaveUserVerificationCode(user.Id);
                await _emailService.SendUserVerificationEmail(user.Email, user.Id, code);
            }
            catch (Exception e)
            {
                //Swallow this exception for now
            }
            
            return user;
        }

        public async Task<User> ReadAsync(Guid id)
            => await _loader.GetAsync(id);
    }
}
