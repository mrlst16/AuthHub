using AuthHub.Interfaces.Passwords;
using AuthHub.Models.Organizations;
using AuthHub.Models.Passwords;
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

        public async Task<(bool, Password)> Set(Guid organizationId, Password request)
        {
            var repo = _crudRepositoryFactory.Get<Organization>();
            var organization = await repo.First(x => x.ID == organizationId);
            var user = organization.Users.First(x => string.Equals(x.UserName, request.UserName));
            user.Password = request;
            var (success, updatedOrg) = await repo.Update(organization, x => x.ID == organizationId);
            return (success, user.Password);
        }

        public async Task<Password> Get(Guid organizationId, string username)
        {
            var repo = _crudRepositoryFactory.Get<Organization>();
            var organization = await repo.First(x => x.ID == organizationId);
            var user = organization.Users.First(x => string.Equals(x.UserName, username));
            return user.Password;
        }
    }
}
