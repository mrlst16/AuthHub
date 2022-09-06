using AuthHub.Interfaces.AuthSetting;
using AuthHub.Models.Organizations;
using Common.Interfaces.Repository;
using System;
using System.Threading.Tasks;

namespace AuthHub.BLL.AuthSetting
{
    public class AuthSettingsLoader : IAuthSettingsLoader
    {
        private readonly ISRDRepository<AuthSettings, Guid> _authSettingsRepo;
        public async Task<AuthSettings> ReadAsync(Guid id)
            => await _authSettingsRepo.ReadAsync(id);
    }
}
