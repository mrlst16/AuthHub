using AuthHub.Interfaces.Organizations;
using AuthHub.Models.Organizations;
using CommonCore.Interfaces.Repository;

namespace AuthHub.BLL.Oranizations
{
    public class OrganizationContext : IOrganizationContext
    {
        private readonly ICrudRepositoryFactory _crudRepositoryFactory;

        public OrganizationContext(
            ICrudRepositoryFactory crudRepositoryFactory
            )
        {
            _crudRepositoryFactory = crudRepositoryFactory;
        }

        public async Task Create(Organization request)
            => await _crudRepositoryFactory
                        .Get<Organization>()
                        .Create(request);

        public async Task<Organization> Get(Guid id)
            => await _crudRepositoryFactory
                        .Get<Organization>()
                        .First(x => x.ID == id);

        public async Task<Organization> Get(string name)
            => await _crudRepositoryFactory
                .Get<Organization>()
                .First(x => x.Name == name);

        public async Task<AuthSettings> GetSettings(Guid organizationId, string name)
        {
            var org = await Get(organizationId);
            return org.Settings
                ?.FirstOrDefault(x => string.Equals(x?.Name, name)) ?? null;
        }

        public async Task<(bool, Organization)> Update(Organization request)
            => await _crudRepositoryFactory
                        .Get<Organization>()
                        .Update(request, x => x.ID == request.ID);

        public async Task<(bool, AuthSettings)> UpdateSettings(Guid organizationId, AuthSettings request)
        {
            var repo = _crudRepositoryFactory.Get<Organization>();
            var org = await repo.First(x => x.ID == organizationId);
            var settings = org.Settings.FirstOrDefault(x => string.Equals(x.Name, request.Name, StringComparison.InvariantCultureIgnoreCase));
            if (org.Settings == null)
                return (false, request);

            settings = request;
            var (success, updatedOrg) = await repo.Update(org, x => x.ID == organizationId);
            return (success, settings);
        }
    }
}