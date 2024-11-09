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
    }
}