using AuthHub.Models.Entities.Organizations;
using System;

namespace AuthHub.Interfaces.AuthSetting
{
    public interface IAuthSettingsContext
    {
        Task<AuthSettings> GetAsync(int id);
        Task<AuthSettings> GetAuthSettingsAsync(int organizationId);
    }
}
