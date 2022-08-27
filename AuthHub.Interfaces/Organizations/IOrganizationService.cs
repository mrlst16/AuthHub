using AuthHub.Models.Organizations;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using AuthHub.Models.Requests;

namespace AuthHub.Interfaces.Organizations
{
    public interface IOrganizationService
    {
        Task<Organization> Create(CreateOrganizationRequest request);
        Task<Organization> Get(Guid organizationId);
        Task<Organization> Get(string name);
        Task<IList<Organization>> GetAll();
        Task<(bool, Organization)> Update(Organization request);
        Task<(bool, AuthSettings)> UpdateSettings(Guid organizationId, AuthSettings request);
        Task<AuthSettings> GetSettings(Guid organizationId, string name);
    }
}