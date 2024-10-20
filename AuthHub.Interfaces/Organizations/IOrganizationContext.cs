using AuthHub.Models.Entities.Organizations;
using System;
using System.Collections.Generic;

namespace AuthHub.Interfaces.Organizations
{
    public interface IOrganizationContext
    {
        Task Create(Organization request);
        Task<Organization> Get(int id);
        Task<Organization> Get(string name);
        Task<IList<Organization>> GetAll();
        Task<AuthSettings> GetSettings(int organizationId, string name);
        Task<(bool, Organization)> Update(Organization request);
        Task<(bool, AuthSettings)> UpdateSettings(int organizationId, AuthSettings request);
        Task<AuthSettings> GetSettings(int authSettingsId);
    }
}