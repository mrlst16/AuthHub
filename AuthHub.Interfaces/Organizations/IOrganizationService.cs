using AuthHub.Models.Entities.Organizations;
using AuthHub.Models.Requests;
using System;
using System.Collections.Generic;

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