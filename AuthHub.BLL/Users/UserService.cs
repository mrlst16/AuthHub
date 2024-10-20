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
using Common.Interfaces.Utilities;
using AuthHub.Models.Responses.User;

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
        private readonly IMapper<User, UserResponse> _userMapper;
        private readonly IUserContext _userContext;

        public UserService(
            IConfiguration configuration,
            IUserLoader loader,
            Func<AuthSchemeEnum, ITokenGenerator> tokenGeneratorFactory,
            IAuthSettingsLoader authSettingsLoader,
            IAuthHubEmailService emailService,
            IVerificationCodeService verificationCodeService,
            IMapper<User, UserResponse> userMapper,
            IUserContext userContext
            )
        {
            _loader = loader;
            _tokenGeneratorFactory = tokenGeneratorFactory;
            _configuration = configuration;
            _authSettingsLoader = authSettingsLoader;
            _emailService = emailService;
            _verificationCodeService = verificationCodeService;
            _userMapper = userMapper;
            _userContext = userContext;
        }

        public async Task<User> CreateAsync(CreateUserRequest item)
        {
            var authSettingsId = item.AuthSettingsID <= 0
                ? _configuration.AuthHubSettingsId()
                : item.AuthSettingsID;

            var authSettings = await _authSettingsLoader.ReadAsync(authSettingsId);
            var tokenGenerator = _tokenGeneratorFactory(authSettings.AuthScheme);

            (byte[] passwordHash, byte[] salt, IEnumerable<ClaimsKey> claimsKeys)
                = await tokenGenerator.NewHash(item.Password, authSettings);

            User user = new()
            {
                AuthSettings = authSettings,
                AuthSettingsId = authSettingsId,
                Email = item.Email,
                FirstName = item.FirstName,
                LastName = item.LastName,
                UserName = item.UserName,
                PhoneNumber = item.PhoneNumber,
                Password = new()
                {
                    PasswordHash = passwordHash,
                    Salt = salt,
                    Claims = claimsKeys.Where(x => x.IsDefault)
                        .Select(x => new ClaimsEntity()
                        {
                            Value = x.DefaultValue,
                            Key = x.Name,
                            ClaimsKeyId = x.Id,
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

        public async Task SendEmailVerificationEmail(int userid)
        {
            var user = await _loader.GetAsync(userid, false);
            VerificationCode code = await _verificationCodeService.GenerateAndSaveUserVerificationCode(user.Id);
            await _emailService.SendUserVerificationEmail(user.Email, user.Id, code);
        }

        public async Task<UserResponse> ReadAsync(int id)
        {
            var entity = await _loader.GetAsync(id);
            return _userMapper.Map(entity);
        }
    }
}
