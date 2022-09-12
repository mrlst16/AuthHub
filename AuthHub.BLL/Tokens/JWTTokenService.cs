using AuthHub.BLL.Common.Extensions;
using AuthHub.Interfaces.Passwords;
using AuthHub.Interfaces.Tokens;
using AuthHub.Models.Tokens;
using Common.Extensions;
using Common.Interfaces.Helpers;
using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Tokens;
using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Security.Claims;
using System.Security.Cryptography;
using System.Threading.Tasks;
using AuthHub.Models.Passwords;
using Common.Interfaces.Utilities;

namespace AuthHub.BLL.Tokens
{
    public class JWTTokenService : ITokenService
    {
        private readonly IPasswordLoader _passwordLoader;
        private readonly IConfiguration _configuration;
        private readonly IApplicationConsistency _applicationConsistency;
        private readonly IMapper<ClaimsEntity, Claim> _claimsMapper;

        public JWTTokenService(
            IPasswordLoader passwordLoader,
            IConfiguration configuration,
            IApplicationConsistency applicationConsistency,
            IMapper<ClaimsEntity, Claim> claimsMapper
            )
        {
            _passwordLoader = passwordLoader;
            _configuration = configuration;
            _applicationConsistency = applicationConsistency;
            _claimsMapper = claimsMapper;
        }

        public byte[] GenerateHash(byte[] password, byte[] salt, int length, int iterations = 100)
        {
            byte[] result = new byte[length];

            using var derivedBytes = new Rfc2898DeriveBytes(password, salt, iterations);
            result = derivedBytes.GetBytes(length);

            return result;
        }

        public byte[] GenerateHash(string password, byte[] salt, int length, int iterations = 100)
            => GenerateHash(_applicationConsistency.GetBytes(password), salt, length, iterations);

        public bool Authenticate(byte[] passwordInRepository, string passwordPassed, byte[] salt, int length, int iterations = 100)
        {
            var requestHash = GenerateHash(passwordPassed, salt, length, iterations);
            return requestHash.BytesEqual(passwordInRepository);
        }

        public async Task<Token> GetToken(Guid userId, string password)
        {
            var loginChallenge = await _passwordLoader.GetLoginChallenge(userId, password);

            if (!Authenticate
                    (
                        loginChallenge.StoredPasswordHash,
                        password,
                        loginChallenge.Salt,
                        loginChallenge.Length,
                        loginChallenge.Iterations
                        )
                    )
                throw new Exception($"Username and Password are not a match for user {userId} while logging in as an ogranization");

            var tad = await _passwordLoader.GetTokenAssemblyData(userId);

            if (
                tad.Claims
                    .FirstOrDefault(x => string.Equals(x.Key, ClaimTypes.Name, StringComparison.InvariantCultureIgnoreCase)
                        ) == null)
                tad.Claims.Add(_configuration.CreateClaimsEntity(ClaimTypes.Name, tad.UserName));

            tad.Claims = tad?.Claims?.Where(x => !string.IsNullOrWhiteSpace(x.Key)).ToList();

            var securityKey = new SymmetricSecurityKey(_applicationConsistency.GetBytes(tad.Key));
            var credentials = new SigningCredentials(securityKey, SecurityAlgorithms.HmacSha256);

            var token = new JwtSecurityToken(
                issuer: tad.Issuer,
                audience: tad.Issuer,
                claims: tad?.Claims?.Select(_claimsMapper.Map) ?? new List<Claim>(),
                expires: tad.ExpirationDate,
                signingCredentials: credentials
            );

            var val = new JwtSecurityTokenHandler().WriteToken(token);
            return new Token(val, token.ValidTo, tad.OrganizationId);
        }
    }
}