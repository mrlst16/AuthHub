using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AuthHub.Models.Requests.AuthSettings;
using AuthHub.Models.Responses.AuthSettings;

namespace AuthHub.Interfaces.AuthSetting
{
    public interface IAuthSettingsService
    {
        Task<AuthSettingsResponse> GetAuthSettingsAsync(int organizationId);
        Task<bool> SaveAuthSettings(int organizationId, AuthSettingsRequest request);
    }
}
