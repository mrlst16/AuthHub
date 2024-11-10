using AuthHub.BLL.Common.Extensions;
using AuthHub.Interfaces.Tokens;
using AuthHub.Interfaces.Users;
using AuthHub.Models.Entities.Tokens;
using AuthHub.Models.Entities.Users;
using AuthHub.Models.Exceptions;
using Common.Interfaces.Helpers;
using Common.Interfaces.Providers;
using Common.Interfaces.Utilities;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;
using AuthHub.Interfaces.AuthSetting;
using AuthHub.Interfaces.Verification;
using AuthHub.Models.Entities.Verification;
using AuthHub.Models.Enums;
using AuthHub.Models.Entities.Claims;
using Common.Helpers;
using Microsoft.IdentityModel.Tokens;

namespace AuthHub.BLL.Tokens
{
    public class JWTTokenService : ITokenService
    {
        private readonly IUserLoader _userLoader;
        private readonly IUserContext _context;
        private readonly IConfiguration _configuration;
        private readonly IApplicationConsistency _applicationConsistency;
        private readonly IDateProvider _dateProvider;
        private readonly IMapper<ClaimsEntity, Claim> _claimsMapper;
        private readonly ITokenContext _tokenContext;
        private readonly IVerificationCodeLoader _verificationCodeLoader;
        private readonly IAuthSettingsContext _authSettingsContext;

        public JWTTokenService(
            IUserLoader userLoader,
            IUserContext context,
            IConfiguration configuration,
            IApplicationConsistency applicationConsistency,
            IDateProvider dateProvider,
            IMapper<ClaimsEntity, Claim> claimsMapper,
            ITokenContext tokenContext,
            IVerificationCodeLoader verificationCodeLoader,
            IAuthSettingsContext authSettingsContext
            )
        {
            _userLoader = userLoader;
            _context = context;
            _configuration = configuration;
            _applicationConsistency = applicationConsistency;
            _dateProvider = dateProvider;
            _claimsMapper = claimsMapper;
            _tokenContext = tokenContext;
            _verificationCodeLoader = verificationCodeLoader;
            _authSettingsContext = authSettingsContext;
        }

        public async Task<Token> GetAsync(int userId)
        {
            var user = await _userLoader.GetAsync(userId);
            var result = await CreateAndSaveToken(user);
            result.User = null;
            return result;
        }

        public async Task<Token> GetAsync(int organizationId, string userName)
        {
            var user = await _context.GetAsync(organizationId, userName);
            var result = await CreateAndSaveToken(organizationId, user);
            result.User = null;
            return result;
        }

        public async Task<Token> GetByPhoneVerificationCode(string phoneNumber, string verificationCode)
        {
            User user = await _userLoader.GetByPhoneNumberAsync(phoneNumber);
            if (user == null)
                throw new Exception($"Cannot find user by phone number {phoneNumber}");

            VerificationCode code =
                await _verificationCodeLoader.GetLatestByUserIdAndType(user.Id, VerificationTypeEnum.PhoneLogin);
            if (code == null)
                throw new Exception($"No verification code exists for user {user.Id}");
            if (code.ExpirationDate < _dateProvider.UTCNow)
                throw new Exception($"Verification code {code.Id} is expired");
            if (code.Code != verificationCode)
                throw new Exception($"Verification code {verificationCode} is invalid");

            return await CreateAndSaveToken(user);
        }

        public async Task<Token> GetRefreshToken(int userId, string refreshToken)
        {
            var user = await _userLoader.GetAsync(userId);
            if (user.Tokens.All(x => x.RefreshToken != refreshToken))
                throw new UnauthorizedException();

            return await GetAsync(userId);
        }

        private async Task<Token> CreateAndSaveToken(User user)
        {
            throw new NotImplementedException();
        }

        private async Task<Token> CreateAndSaveToken(int organizationId, User user)
        {
            var userClaims = user.Claims;

            if (
                userClaims
                    .FirstOrDefault(x => string.Equals(x.Key, ClaimTypes.Name, StringComparison.InvariantCultureIgnoreCase)
                    ) == null)
                userClaims.Add(_configuration.CreateClaimsEntity(ClaimTypes.Name, user.UserName));
            userClaims.Add(new ClaimsEntity()
                {
                    Key = "Id",
                    Value = user.Id.ToString()
                }
            );
            userClaims = userClaims?.Where(x => !string.IsNullOrWhiteSpace(x.Key)).ToList();

            var authSettings = await _authSettingsContext.GetAuthSettingsAsync(organizationId);

            var securityKey = new SymmetricSecurityKey(_applicationConsistency.GetBytes(authSettings.Key));
            var credentials = new SigningCredentials(securityKey, SecurityAlgorithms.HmacSha256);
            var expirationDate = _dateProvider.UTCNow.AddMinutes(authSettings.ExpirationMinutes);
            var token = new JwtSecurityToken(
                issuer: authSettings.Issuer,
                audience: authSettings.Audience,
                claims: userClaims.Select(_claimsMapper.Map) ?? new List<Claim>(),
                expires: expirationDate,
                signingCredentials: credentials
            );

            var result = new Token()
            {
                Value = new JwtSecurityTokenHandler().WriteToken(token),
                ExpirationDate = expirationDate,
                RefreshToken = StringHelper.RandomAlphanumericString(64),
                UserId = user.Id
            };

            await _tokenContext.AddAsync(result);
            return result;
        }
    }
}