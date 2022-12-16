using AuthHub.BLL.Common.Extensions;
using AuthHub.Interfaces.Tokens;
using AuthHub.Interfaces.Users;
using AuthHub.Models.Entities.Passwords;
using AuthHub.Models.Tokens;
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
        public JWTTokenService(
            IUserLoader userLoader,
            IConfiguration configuration,
            IApplicationConsistency applicationConsistency,
            IDateProvider dateProvider,
            IMapper<ClaimsEntity, Claim> claimsMapper
            )
        {
            _userLoader = userLoader;
            _configuration = configuration;
            _applicationConsistency = applicationConsistency;
            _dateProvider = dateProvider;
            _claimsMapper = claimsMapper;
        }

        public async Task<Token> GetAsync(Guid userId)
        {
            var user = await _userLoader.GetAsync(userId);
            var authSettings = user.AuthSettings;
            var password = user.Password;
            var userClaims = user.Password.Claims;

            if (
                userClaims
                    .FirstOrDefault(x => string.Equals(x.Key, ClaimTypes.Name, StringComparison.InvariantCultureIgnoreCase)
                    ) == null)
                userClaims.Add(_configuration.CreateClaimsEntity(ClaimTypes.Name, user.UserName));

            userClaims = userClaims?.Where(x => !string.IsNullOrWhiteSpace(x.Key)).ToList();

            var securityKey = new SymmetricSecurityKey(_applicationConsistency.GetBytes(authSettings.Key));
            var credentials = new SigningCredentials(securityKey, SecurityAlgorithms.HmacSha256);
            var expirationDate = _dateProvider.UTCNow.AddMinutes(authSettings.ExpirationMinutes);
            var token = new JwtSecurityToken(
                issuer: authSettings.Issuer,
                audience: authSettings.Issuer,
                claims: userClaims.Select(_claimsMapper.Map) ?? new List<Claim>(),
                expires: expirationDate,
                signingCredentials: credentials
            );

            var refreshToken = StringHelper.RandomAlphanumericString(64);

            return new Token()
            {
                Value = new JwtSecurityTokenHandler().WriteToken(token),
                ExpirationDate = expirationDate,
            };
        }
    }
}