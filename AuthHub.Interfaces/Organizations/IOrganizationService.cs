using AuthHub.Models.Organizations;
using System;
using System.Threading.Tasks;

namespace AuthHub.Interfaces.Organizations
{
    public interface IOrganizationService
    {
        Task<Organization> Create(CreateOrganizationRequest request);
        Task<(bool, Organization)> Update(Organization request);
        Task<(bool, OrganizationSettings)> UpdateSettings(Guid organizationId, OrganizationSettings request);
    }
}