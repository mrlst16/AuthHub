using System;

namespace AuthHub.Interfaces.AuthSetting
{
    public interface IAuthSettingsContext
    {
        public Task<Models.Organizations.AuthSettings> GetAsync(Guid id);
    }
}
