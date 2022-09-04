using AuthHub.Models.Organizations;
using AuthHub.Models.Users;
using Common.Interfaces.Repository;

namespace AuthHub.BLL.Common.Extensions
{
    public static class IRepositoryFactoryExtensions
    {
        public static async Task<(Organization, AuthSettings, User)> GetOrganizationAuthSettingsAndUser(this ICrudRepositoryFactory factory, UserPointer pointer)
        {
            var repo = factory.Get<Organization>();
            return await repo.GetOrganizationAuthSettingsAndUser(pointer);
        }

        public static async Task<(Organization, AuthSettings, User)> GetOrganizationAuthSettingsAndUser(this ICrudRepository<Organization> repo, UserPointer pointer)
        {
            var organization = await repo.First(x => x.Id == pointer.OrganizationID);
            if (organization == null)
                return (null, null, null);
            var authSettings = organization.Settings.FirstOrDefault(x => string.Equals(x.Name, pointer.AuthSettingsName));
            if (authSettings == null)
                return (organization, null, null);
            var user = authSettings.Users.FirstOrDefault(x => string.Equals(x.UserName, pointer.UserName));
            if (user == null)
                return (organization, authSettings, null);

            return (organization, authSettings, user);
        }

        public static async Task<(bool, Organization)> SaveUser(this ICrudRepository<Organization> repo, UserPointer pointer, User user)
        {
            var (org, authSettings, userFromDatabase) = await repo.GetOrganizationAuthSettingsAndUser(pointer);
            userFromDatabase = user;
            return await repo.Update(org, x => x.Id == pointer.OrganizationID);
        }

        public static async Task<(bool, Organization)> SaveUser(this ICrudRepositoryFactory factory, UserPointer pointer, User user)
            => await SaveUser(factory.Get<Organization>(), pointer, user);
    }
}
