using System;
using AuthHub.Models.Organizations;

namespace AuthHub.Interfaces.AuthSetting
{
    public interface IAuthSettingsLoader
    {
        Task<AuthSettings> ReadAsync(Guid id);
    }
}
