using AuthHub.Interfaces.AuthSetting;
using AuthHub.Interfaces.Emails;
using AuthHub.Interfaces.Tokens;
using AuthHub.Interfaces.Users;
using AuthHub.Interfaces.Verification;
using AuthHub.Models.Entities.Users;
using AuthHub.Models.Entities.Verification;
using AuthHub.Models.Enums;
using AuthHub.Models.Requests;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AuthHub.Interfaces.Claims;
using Common.Interfaces.Utilities;
using AuthHub.Models.Responses.User;
using AuthHub.Models.Entities.Claims;

namespace AuthHub.BLL.Users
{
    public class UserService : IUserService
    {
        private readonly IUserLoader _loader;
        private readonly Func<AuthSchemeEnum, ITokenGenerator> _tokenGeneratorFactory;
        private readonly IAuthSettingsLoader _authSettingsLoader;
        private readonly IAuthHubEmailService _emailService;
        private readonly IVerificationCodeService _verificationCodeService;
        private readonly IMapper<User, UserResponse> _userMapper;
        private readonly IUserContext _userContext;
        private readonly IClaimsLoader _claimsLoader;

        public UserService(
            IUserLoader loader,
            Func<AuthSchemeEnum, ITokenGenerator> tokenGeneratorFactory,
            IAuthSettingsLoader authSettingsLoader,
            IAuthHubEmailService emailService,
            IVerificationCodeService verificationCodeService,
            IMapper<User, UserResponse> userMapper,
            IUserContext userContext,
            IClaimsLoader claimsLoader
            )
        {
            _loader = loader;
            _tokenGeneratorFactory = tokenGeneratorFactory;
            _authSettingsLoader = authSettingsLoader;
            _emailService = emailService;
            _verificationCodeService = verificationCodeService;
            _userMapper = userMapper;
            _userContext = userContext;
            _claimsLoader = claimsLoader;
        }

        public async Task<User> CreateAsync(int organizationId, CreateUserRequest item)
        {
            var authSettings = await _authSettingsLoader.ReadAsync(item.AuthSettingsId);
            var tokenGenerator = _tokenGeneratorFactory(authSettings.AuthScheme);

            (byte[] passwordHash, byte[] salt, IEnumerable<ClaimsKey> claimsKeys)
                = await tokenGenerator.NewHash(item.Password, authSettings);

            User user = new()
            {
                AuthSettings = authSettings,
                AuthSettingsId = item.AuthSettingsId,
                Email = item.Email,
                UserName = item.UserName,
                PhoneNumber = item.PhoneNumber,
                Password = new()
                {
                    PasswordHash = passwordHash,
                    Salt = salt
                },
                Claims = (await _claimsLoader.GetClaimsFromTemplate(organizationId, item.ClaimsTemplateName)).ToList()
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
