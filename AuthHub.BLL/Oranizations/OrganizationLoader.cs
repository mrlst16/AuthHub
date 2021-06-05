using AuthHub.Interfaces.Organizations;
using AuthHub.Models.Organizations;
using CommonCore.Interfaces.Repository;
using CommonCore2.Repository.MongoDb;
using System;
using System.Threading.Tasks;

namespace AuthHub.BLL.Oranizations
{
    public class OrganizationLoader : IOrganizationLoader
    {
        private readonly ICrudRepositoryFactory _crudRepositoryFactory;

        public OrganizationLoader(
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

        public async Task<(bool, Organization)> Update(Organization request)
            => await _crudRepositoryFactory
                        .Get<Organization>()
                        .Update(request, x => x.ID == request.ID);

        public async Task<(bool, OrganizationSettings)> UpdateSettings(Guid organizationId, OrganizationSettings request)
        {
            var repo = _crudRepositoryFactory.Get<Organization>();
            var org = await repo.First(x => x.ID == organizationId);
            org.Settings = request;
            var (success, updatedOrg) = await repo.Update(org, x => x.ID == organizationId);
            return (success, updatedOrg.Settings);
        }
    }
}