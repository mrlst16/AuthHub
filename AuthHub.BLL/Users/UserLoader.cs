using AuthHub.Interfaces.Users;
using AuthHub.Models.Organizations;
using AuthHub.Models.Users;
using CommonCore.Interfaces.Repository;
using System;
using System.Linq;
using System.Threading.Tasks;

namespace AuthHub.BLL.Users
{
    public class UserLoader : IUserLoader
    {
        private readonly ICrudRepositoryFactory _crudRepositoryFactory;
        public UserLoader(
            ICrudRepositoryFactory crudRepositoryFactory
            )
        {
            _crudRepositoryFactory = crudRepositoryFactory;
        }

        public async Task<User> Get(Guid organizationId, string username)
        {
            var org = await _crudRepositoryFactory
                .Get<Organization>()
                .First(x => x.ID == organizationId);
            return org.Users.FirstOrDefault(x => string.Equals(x.UserName, username, StringComparison.InvariantCultureIgnoreCase));
        }

        public async Task<User> Create(Guid organizationId, User user)
        {
            var repo = _crudRepositoryFactory.Get<Organization>();
            var org = await repo.First(x => x.ID == organizationId);
            var existingUser = org.Users.FirstOrDefault(x => string.Equals(x.UserName, user.UserName, StringComparison.InvariantCultureIgnoreCase));
            if (existingUser != null)
                throw new Exception($"User {user.UserName} already exists in organization {organizationId}");

            org.Users.Add(user);
            var (success, organization) = await repo.Update(org, x => x.ID == organizationId);

            if (!success)
                throw new Exception($"Unsuccessful Update");

            return user;
        }

        public async Task<User> Update(Guid organizationId, User user)
        {
            var repo = _crudRepositoryFactory.Get<Organization>();
            var org = await repo.First(x => x.ID == organizationId);
            var existingUser = org.Users.FirstOrDefault(x => string.Equals(x.UserName, user.UserName, StringComparison.InvariantCultureIgnoreCase));
            if (existingUser == null)
                throw new Exception($"User {user.UserName} does not exists in organization {organizationId}");
            var (success, organization) = await repo.Update(org, x => x.ID == organizationId);
            if (!success)
                throw new Exception($"Unsuccessful Update");

            return user;
        }
    }
}
