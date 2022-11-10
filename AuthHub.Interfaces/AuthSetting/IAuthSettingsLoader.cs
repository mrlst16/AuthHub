using AuthHub.Models.Organizations;
using System;

namespace AuthHub.Interfaces.AuthSetting
{
    public interface IAuthSettingsLoader
    {
        Task<AuthSettings> ReadAsync(Guid id);
    }
}
