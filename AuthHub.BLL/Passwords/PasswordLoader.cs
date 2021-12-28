using AuthHub.Common.Extensions;
using AuthHub.Interfaces.Passwords;
using AuthHub.Models.Organizations;
using AuthHub.Models.Passwords;
using AuthHub.Models.Users;
using CommonCore.Extensions;
using CommonCore.Interfaces.Repository;
using CommonCore.Models.Exceptions;
using System;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;

namespace AuthHub.BLL.Passwords
{
    public class PasswordLoader : IPasswordLoader
    {
        private ICrudRepositoryFactory _crudRepositoryFactory;

        public PasswordLoader(
            ICrudRepositoryFactory crudRepositoryFactory
            )
        {
            _crudRepositoryFactory = crudRepositoryFactory;
        }

        public async Task<(bool, Password)> Set(Guid organizationId, string authSettingsname, Password request)
        {
            var repo = _crudRepositoryFactory.Get<Organization>();
            var organization = await repo.First(x => x.ID == organizationId);
            var settings = organization.GetSettings(authSettingsname);
            var user = settings.Users.First(x => string.Equals(x.UserName, request.UserName));
            user.Password = request;
            var (success, updatedOrg) = await repo.Update(organization, x => x.ID == organizationId);
            return (success, user.Password);
        }

        public async Task<Password> Get(Guid organizationId, string authSettingsname, string username)
        {
            var repo = _crudRepositoryFactory.Get<Organization>();
            var organization = await repo.First(x => x.ID == organizationId);
            var settings = organization.GetSettings(authSettingsname);
            var user = settings.Users.First(x => string.Equals(x.UserName, username));
            return user.Password;
        }

        public async Task<PasswordResetToken> GeneratePasswordResetToken(UserPointer userPointer)
        {
            var repo = _crudRepositoryFactory.Get<PasswordResetToken>();
            var organizationsRepo = _crudRepositoryFactory.Get<Organization>();
            var organization = await organizationsRepo.First(x => x.ID == userPointer.OrganizationID);
            var authSettings = organization.GetSettings(userPointer.AuthSettingsName);
            var user = authSettings.Users.FirstOrDefault(x => string.Equals(x.UserName, userPointer.UserName, StringComparison.InvariantCultureIgnoreCase));
            var salt = GenerateSalt(8);
            var password = Guid.NewGuid().ToByteArray();

            var result = new PasswordResetToken()
            {
                AuthSettingsName = userPointer.AuthSettingsName,
                OrganizationID = userPointer.OrganizationID,
                UserName = userPointer.UserName,
                Email = user.Email,
                ExpirationDate = DateTime.UtcNow.AddMinutes(authSettings.PasswordResetTokenExpirationMinutes),
                Salt = salt,
                Password = password
            };

            await repo.Create(result);
            result.Token = GenerateHash(password, salt, 8);
            return (result);
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

        public async Task AuthenticateAndUpdateToken(ResetPasswordRequest request)
        {
            var tokenRepo = _crudRepositoryFactory.Get<PasswordResetToken>();
            var token = await tokenRepo.First(x =>
                    x.Email == request.Email
                    && x.OrganizationID == request.OrganizationID
                    && x.AuthSettingsName == request.AuthSettingsName
                    && x.ExpirationDate <= request.ExpirationDate
                    && x.IsActive
                );

            if (token == null)
                throw new HttpException("Unable to authenticate reset password token", 403);

            if (!AuthenticateResetToken(token, request.Token))
                throw new HttpException("Unable to authenticate reset password token", 403);

            token.IsActive = false;
            await tokenRepo.Update(token, x => x.Email == request.Email
                    && x.OrganizationID == request.OrganizationID
                    && x.AuthSettingsName == request.AuthSettingsName
                    && x.ExpirationDate <= request.ExpirationDate);
        }

        private bool AuthenticateResetToken(PasswordResetToken token, byte[] passedToken)
        {
            var hash = GenerateHash(token.Password, token.Salt, 8);
            return hash.BytesEqual(passedToken);
        }

    }
}
