using AuthHub.Interfaces.Passwords;
using AuthHub.Models.Passwords;
using AuthHub.Models.Users;
using CommonCore.Models.Exceptions;
using CommonCore2.Extensions;
using System;
using System.Security.Cryptography;
using System.Threading.Tasks;

namespace AuthHub.BLL.Passwords
{
    public class PasswordLoader : IPasswordLoader
    {

        private readonly IPasswordContext _passwordContext;

        public PasswordLoader(
            IPasswordContext passwordContext
            )
        {
            _passwordContext = passwordContext;
        }


        public async Task AuthenticateAndUpdateToken(ResetPasswordRequest request)
        {
            var token = await _passwordContext.GetPasswordResetToken(
                request.Email,
                request.OrganizationID,
                request.AuthSettingsName,
                request.ExpirationDate
                );

            if (token == null)
                throw new HttpException("Unable to authenticate reset password token", 403);

            if (!AuthenticateResetToken(token, request.Token))
                throw new HttpException("Unable to authenticate reset password token", 403);

            token.IsActive = false;
            //await tokenRepo.Update(token, x => x.Email == request.Email
            //        && x.OrganizationID == request.OrganizationID
            //        && x.AuthSettingsName == request.AuthSettingsName
            //        && x.ExpirationDate <= request.ExpirationDate);
            throw new NotImplementedException();
        }

        private bool AuthenticateResetToken(PasswordResetToken token, byte[] passedToken)
        {
            var hash = GenerateHash(token.Password, token.Salt, 8);
            return hash.BytesEqual(passedToken);
        }

        public async Task<PasswordResetToken> GeneratePasswordResetToken(UserPointer userPointer)
        {
            //var repo = _crudRepositoryFactory.Get<PasswordResetToken>();
            //var organizationsRepo = _crudRepositoryFactory.Get<Organization>();
            //var organization = await organizationsRepo.First(x => x.ID == userPointer.OrganizationID);
            //var authSettings = organization.GetSettings(userPointer.AuthSettingsName);
            //var user = authSettings.Users.FirstOrDefault(x => string.Equals(x.UserName, userPointer.UserName, StringComparison.InvariantCultureIgnoreCase));
            //var salt = GenerateSalt(8);
            //var password = Guid.NewGuid().ToByteArray();

            //var result = new PasswordResetToken()
            //{
            //    AuthSettingsName = userPointer.AuthSettingsName,
            //    OrganizationID = userPointer.OrganizationID,
            //    UserName = userPointer.UserName,
            //    Email = user.Email,
            //    ExpirationDate = DateTime.UtcNow.AddMinutes(authSettings.PasswordResetTokenExpirationMinutes),
            //    Salt = salt,
            //    Password = password
            //};

            //await repo.Create(result);
            //result.Token = GenerateHash(password, salt, 8);
            //return (result);
            throw new NotImplementedException();
        }

        public async Task<Password> Get(Guid organizationId, string authSettingsname, string username)
            => await _passwordContext.Get(organizationId, authSettingsname, username);

        public async Task<(bool, Password)> Set(Guid organizationId, string authSettingsname, Password request)
            => await _passwordContext.Set(organizationId, authSettingsname, request);

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
    }
}
