using AuthHub.Models.Entities.Organizations;
using System;

namespace AuthHub.Interfaces.AuthSetting
{
    public interface IAuthSettingsLoader
    {
        Task<AuthSettings> ReadAsync(int id);
    }
}
