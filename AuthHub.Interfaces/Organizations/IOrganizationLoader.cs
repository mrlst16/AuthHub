using AuthHub.Models.Organizations;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace AuthHub.Interfaces.Organizations
{
    public interface IOrganizationLoader
    {
        Task Create(Organization request);
        Task<Organization> Get(Guid id);
        Task<Organization> Get(string name);
        Task<IList<Organization>> GetAll();
        Task<AuthSettings> GetSettings(Guid organizationId, string name);
        Task<(bool, Organization)> Update(Organization request);
        Task<(bool, AuthSettings)> UpdateSettings(Guid organizationId, AuthSettings request);
        Task<AuthSettings> GetSettings(Guid authSettingsId);
    }
}