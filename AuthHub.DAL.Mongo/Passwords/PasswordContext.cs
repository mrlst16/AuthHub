using AuthHub.Common.Extensions;
using AuthHub.Interfaces.Passwords;
using AuthHub.Models.Organizations;
using AuthHub.Models.Passwords;
using AuthHub.Models.Users;
using CommonCore.Interfaces.Repository;
using CommonCore.Models.Exceptions;
using CommonCore2.Extensions;
using System.Security.Cryptography;

namespace AuthHub.BLL.Passwords
{
    public class PasswordContext : IPasswordContext
    {
        private ICrudRepositoryFactory _crudRepositoryFactory;

        public PasswordContext(
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
        public async Task<PasswordResetToken> GetPasswordResetToken(string email, Guid organizationId, string authSettingsName, DateTime expirationDate)
        {
            throw new NotImplementedException();
        }

        public async Task SavePasswordResetToken(PasswordResetToken token)
        {
            
        }
    }
}
