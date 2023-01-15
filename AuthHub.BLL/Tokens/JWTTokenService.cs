using AuthHub.BLL.Common.Extensions;
using AuthHub.Interfaces.Tokens;
using AuthHub.Interfaces.Users;
using AuthHub.Models.Entities.Passwords;
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

        public JWTTokenService(
            IUserLoader userLoader,
            IConfiguration configuration,
            IApplicationConsistency applicationConsistency,
            IDateProvider dateProvider,
            IMapper<ClaimsEntity, Claim> claimsMapper,
            ITokenLoader tokenLoader
            )
        {
            _userLoader = userLoader;
            _configuration = configuration;
            _applicationConsistency = applicationConsistency;
            _dateProvider = dateProvider;
            _claimsMapper = claimsMapper;
            _tokenLoader = tokenLoader;
        }

        public async Task<Token> GetAsync(Guid userId)
        {
            var user = await _userLoader.GetAsync(userId);
            var result = await CreateAndSaveToken(user);
            result.User = null;
            return result;
        }

        public async Task<Token> GetRefreshToken(Guid userId, string refreshToken)
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

            userClaims = userClaims?.Where(x => !string.IsNullOrWhiteSpace(x.Key)).ToList();

            var securityKey = new SymmetricSecurityKey(_applicationConsistency.GetBytes(user.AuthSettings.Key));
            var credentials = new SigningCredentials(securityKey, SecurityAlgorithms.HmacSha256);
            var expirationDate = _dateProvider.UTCNow.AddMinutes(user.AuthSettings.ExpirationMinutes);
            var token = new JwtSecurityToken(
                issuer: user.AuthSettings.Issuer,
                audience: user.AuthSettings.Issuer,
                claims: userClaims.Select(_claimsMapper.Map) ?? new List<Claim>(),
                expires: expirationDate,
                signingCredentials: credentials
            );

            var result = new Token()
            {
                Id = Guid.NewGuid(),
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