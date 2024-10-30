using AuthHub.Models.Entities.Organizations;
using AuthHub.Models.Requests;
using System;
using System.Collections.Generic;
using AuthHub.Models.Tokens;

namespace AuthHub.Interfaces.Organizations
{
    public interface IOrganizationService
    {
        Task<Organization> CreateAsync(CreateOrganizationRequest request);
        Task<Token> LoginAsync(OrganizationLoginRequest request);
        Task<Organization> GetAsync(int organizationId);
        Task<Organization> GetAsync(string name);
        Task<IList<Organization>> GetAll();
        Task<(bool, Organization)> Update(Organization request);
        Task<(bool, AuthSettings)> UpdateSettings(int organizationId, AuthSettings request);
        Task<AuthSettings> GetSettings(int organizationId, string name);
    }
}