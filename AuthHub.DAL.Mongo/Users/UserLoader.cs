using AuthHub.Common.Extensions;
using AuthHub.Interfaces.Users;
using AuthHub.Models.Organizations;
using AuthHub.Models.Users;
using CommonCore.Interfaces.Repository;
using MongoDB.Driver;

namespace AuthHub.BLL.Users
{
    public class UserContext : IUserContext
    {
        private readonly ICrudRepositoryFactory _crudRepositoryFactory;

        public UserContext(
            ICrudRepositoryFactory crudRepositoryFactory
            )
        {
            _crudRepositoryFactory = crudRepositoryFactory;
        }

        public async Task<User> Create(Guid organizationId, string authUserName, User user)
        {
            var repo = _crudRepositoryFactory.Get<Organization>();
            var org = await repo.First(x => x.ID == organizationId);
            var existingUser = org.GetSettings(authUserName)
                .Users.FirstOrDefault(x => string.Equals(x.UserName, user.UserName, StringComparison.InvariantCultureIgnoreCase));
            if (existingUser != null)
                throw new Exception($"User {user.UserName} already exists in organization {organizationId}");

            org.GetSettings(authUserName).Users.Add(user);
            var (success, organization) = await repo.Update(org, x => x.ID == organizationId);

            if (!success)
                throw new Exception($"Unsuccessful Update");

            return user;
        }

        public async Task<User> Update(Guid organizationId, string authSettingsName, User user)
        {
            var repo = _crudRepositoryFactory.Get<Organization>();
            var org = await repo.First(x => x.ID == organizationId);
            var existingUser = org.GetSettings(authSettingsName)
                .Users
                .FirstOrDefault(x => string.Equals(x.UserName, user.UserName, StringComparison.InvariantCultureIgnoreCase));
            existingUser = user;
            if (existingUser == null)
                throw new Exception($"User {user.UserName} does not exists in organization {organizationId}");
            var (success, organization) = await repo.Update(org, x => x.ID == organizationId);
            if (!success)
                throw new Exception($"Unsuccessful Update");

            return user;
        }

        public async Task<User> Get(Guid organizationId, string authSettingsName, string username)
        {
            var org = await _crudRepositoryFactory
                .Get<Organization>()
                .First(x => x.ID == organizationId);
            return org.GetSettings(authSettingsName)
                .Users.FirstOrDefault(x => string.Equals(x.UserName, username, StringComparison.InvariantCultureIgnoreCase));
        }

        public async Task<User> Get(UserPointer userPointer)
            => await Get(userPointer.OrganizationID, userPointer.AuthSettingsName, userPointer.UserName);

        public async Task<User> Update(UserPointer pointer, User user)
            => await Update(pointer.OrganizationID, pointer.AuthSettingsName, user);
    }
}