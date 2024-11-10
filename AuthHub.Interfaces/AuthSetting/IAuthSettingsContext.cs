using AuthHub.Models.Entities.Organizations;
using System;
using AuthHub.Models.Requests.AuthSettings;

namespace AuthHub.Interfaces.AuthSetting
{
    public interface IAuthSettingsContext
    {
        Task<AuthSettings> GetAsync(int id);
        Task<AuthSettings> GetAuthSettingsAsync(int organizationId);
        Task<bool> SaveAuthSettings(int organizationId, AuthSettingsRequest request);
    }
}
