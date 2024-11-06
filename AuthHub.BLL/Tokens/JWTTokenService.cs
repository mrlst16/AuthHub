using AuthHub.BLL.Common.Extensions;
using AuthHub.Interfaces.Tokens;
using AuthHub.Interfaces.Users;
using AuthHub.Models.Entities.Tokens;
using AuthHub.Models.Entities.Users;
using AuthHub.Models.Exceptions;
using Common.Helpers;
using Common.Interfaces.Helpers;
using Common.Interfaces.Providers;
using Common.Interfaces.Utilities;
using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Tokens;
using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;
using AuthHub.Interfaces.Verification;
using AuthHub.Models.Entities.Verification;
using AuthHub.Models.Enums;
using AuthHub.Models.Entities.Claims;

namespace AuthHub.BLL.Tokens
{
    public class JWTTokenService : ITokenService
    {
        private readonly IUserLoader _userLoader;
        private readonly IConfiguration _configuration;
        private readonly IApplicationConsistency _applicationConsistency;
        private readonly IDateProvider _dateProvider;
        private readonly IMapper<ClaimsEntity, Claim> _claimsMapper;
        private readonly ITokenLoader _tokenLoader;
        private readonly IVerificationCodeLoader _verificationCodeLoader;

        public JWTTokenService(
            IUserLoader userLoader,
            IConfiguration configuration,
            IApplicationConsistency applicationConsistency,
            IDateProvider dateProvider,
            IMapper<ClaimsEntity, Claim> claimsMapper,
            ITokenLoader tokenLoader,
            IVerificationCodeLoader verificationCodeLoader
            )
        {
            _userLoader = userLoader;
            _configuration = configuration;
            _applicationConsistency = applicationConsistency;
            _dateProvider = dateProvider;
            _claimsMapper = claimsMapper;
            _tokenLoader = tokenLoader;
            _verificationCodeLoader = verificationCodeLoader;
        }

        public async Task<Token> GetAsync(int userId)
        {
            var user = await _userLoader.GetAsync(userId);
            var result = await CreateAndSaveToken(user);
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
            var userClaims = user.Password.Claims;

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

            var securityKey = new SymmetricSecurityKey(_applicationConsistency.GetBytes(user.AuthSettings.Key));
            var credentials = new SigningCredentials(securityKey, SecurityAlgorithms.HmacSha256);
            var expirationDate = _dateProvider.UTCNow.AddMinutes(user.AuthSettings.ExpirationMinutes);
            var token = new JwtSecurityToken(
                issuer: user.AuthSettings.Issuer,
                audience: user.AuthSettings.Audience,
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

            await _userLoader.AddToken(user, result);
            return result;
        }
    }
}