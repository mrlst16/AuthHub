using AuthHub.BLL.Common.Extensions;
using AuthHub.Interfaces.AuthSetting;
using AuthHub.Interfaces.Tokens;
using AuthHub.Interfaces.Users;
using AuthHub.Models.Enums;
using AuthHub.Models.Passwords;
using AuthHub.Models.Users;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AuthHub.Interfaces.Emails;

namespace AuthHub.BLL.Users
{
    public class UserService : IUserService
    {
        private readonly IUserLoader _loader;
        private readonly Func<AuthSchemeEnum, ITokenGenerator> _tokenGeneratorFactory;
        private readonly IConfiguration _configuration;
        private readonly IAuthSettingsLoader _authSettingsLoader;
        private readonly IAuthHubEmailService _emailService;

        public UserService(
            IConfiguration configuration,
            IUserLoader loader,
            Func<AuthSchemeEnum, ITokenGenerator> tokenGeneratorFactory,
            IAuthSettingsLoader authSettingsLoader,
            IAuthHubEmailService emailService
            )
        {
            _loader = loader;
            _tokenGeneratorFactory = tokenGeneratorFactory;
            _configuration = configuration;
            _authSettingsLoader = authSettingsLoader;
            _emailService = emailService;
        }

        public async Task<Guid> CreateAsync(CreateUserRequest item)
        {
            var authSettings = await _authSettingsLoader.ReadAsync(_configuration.AuthHubSettingsId());
            var tokenGenerator = _tokenGeneratorFactory(AuthSchemeEnum.JWT);

            (byte[] passwordHash, byte[] salt, IEnumerable<ClaimsKey> claimsKeys)
                = await tokenGenerator.NewHash(item.Password, authSettings);

            var newUserId = Guid.NewGuid();
            var newPasswordId = Guid.NewGuid();

            User user = new()
            {
                Id = newUserId,
                Email = item.Email,
                FirstName = item.FirstName,
                LastName = item.LastName,
                UserName = item.UserName,
                IsOrganization = false,
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
            await _emailService.SendUserVerificationEmail(user.Email, user.Id, string.Empty);
            return user.Id;
        }

        public async Task<User> ReadAsync(Guid id)
            => await _loader.GetAsync(id);
    }
}
