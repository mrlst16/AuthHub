using AuthHub.Models.Entities.Organizations;
using System;

namespace AuthHub.Interfaces.AuthSetting
{
    public interface IAuthSettingsContext
    {
        public Task<AuthSettings> GetAsync(int id);
    }
}
