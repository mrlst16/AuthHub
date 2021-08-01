using AuthHub.Extensions;
using AuthHub.Interfaces.Passwords;
using AuthHub.Models.Organizations;
using AuthHub.Models.Passwords;
using AuthHub.Models.Users;
using CommonCore.Interfaces.Repository;
using System;
using System.Linq;
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

            var result = new PasswordResetToken()
            {
                AuthSettingsName = userPointer.AuthSettingsName,
                OrganizationID = userPointer.OrganizationID,
                Token = Guid.NewGuid(),
                UserName = userPointer.UserName,
                Email = user.Email,
                ExpirationDate = DateTime.UtcNow.AddMinutes(authSettings.PasswordResetTokenExpirationMinutes)
            };

            await repo.Create(result);
            return result;
        }
    }
}