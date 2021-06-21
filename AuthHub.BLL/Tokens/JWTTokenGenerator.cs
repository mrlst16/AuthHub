using AuthHub.Extensions;
using AuthHub.Interfaces.Tokens;
using AuthHub.Models.Organizations;
using AuthHub.Models.Passwords;
using AuthHub.Models.Tokens;
using CommonCore2.Extensions;
using Microsoft.IdentityModel.Tokens;
using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Security.Claims;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;

namespace AuthHub.BLL.Tokens
{
    public class JWTTokenGenerator : ITokenGenerator
    {
        public JWTTokenGenerator(
            )
        {
        }

        public async Task<Token> GetToken(PasswordRequest request, Organization organization)
        {
            try
            {
                var passwordRecord = organization
                                        .GetSettings(request.SettingsName)
                                        ?.Users.FirstOrDefault(x => string.Equals(x.UserName, request.UserName))
                                        ?.Password
                                            ?? null;
                var authSettings = organization.GetSettings(request.SettingsName);

                if (!Authenticate(request, passwordRecord))
                    throw new Exception($"Username and Password are not a match for user {request.UserName} in organization {organization.ID}");

                if (passwordRecord.Claims == null)
                    passwordRecord.Claims = new List<Claim>();
                if (passwordRecord.Claims.FirstOrDefault(x => x.Type == ClaimTypes.Name) == null)
                    passwordRecord.Claims.Add(new Claim(ClaimTypes.Name, passwordRecord.UserName));

                passwordRecord.Claims = passwordRecord?.Claims?.Where(x => !string.IsNullOrWhiteSpace(x.Type)).ToList();

                var securityKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(authSettings.Key));
                var credentials = new SigningCredentials(securityKey, SecurityAlgorithms.HmacSha256);

                var token = new JwtSecurityToken(
                    issuer: authSettings.Issuer,
                    audience: authSettings.Issuer,
                    claims: passwordRecord.Claims,
                    expires: DateTime.Now.AddMinutes(authSettings.ExpirationMinutes),
                    signingCredentials: credentials
                    );

                var val = new JwtSecurityTokenHandler().WriteToken(token);
                return new Token(val, token.ValidTo, organization.ID);
            }
            catch (Exception e)
            {

            }
            return null;
        }

        private byte[] GenerateSalt(int length)
        {
            byte[] result = new byte[length];

            using (var rng = new RNGCryptoServiceProvider())
            {
                rng.GetBytes(result);
            }
            return result;
        }

        private byte[] GenerateHash(byte[] password, byte[] salt, int length, int iterations = 100)
        {
            byte[] result = new byte[length];

            using (var derviedBytes = new Rfc2898DeriveBytes(password, salt, iterations))
            {
                result = derviedBytes.GetBytes(length);
            }

            return result;
        }

        private byte[] GenerateHash(string password, byte[] salt, int length, int iterations = 100)
            => GenerateHash(UTF8Encoding.UTF8.GetBytes(password), salt, length, iterations);

        private (byte[], byte[]) GenerateHash(string password, int saltLength, int hashLength, int iterations = 100)
        {
            var salt = GenerateSalt(saltLength);
            return (GenerateHash(password, salt, hashLength, iterations), salt);
        }

        public bool Authenticate(PasswordRequest request, Password password)
        {
            var requestHash = GenerateHash(request.Password, password.Salt, password.HashLength, password.Iterations);
            return requestHash.BytesEqual(password.PasswordHash);
        }

        public async Task<(byte[], byte[])> GetHash(PasswordRequest passwordRequest, Organization organization)
        {
            var settings = organization.GetSettings(passwordRequest.SettingsName);
            var salt = GenerateSalt(settings.SaltLength);
            return (GenerateHash(passwordRequest.Password, salt, settings.HashLength, settings.Iterations), salt);
        }
    }
}