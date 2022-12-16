using AuthHub.Interfaces.AuthSetting;
using AuthHub.Models.Entities.Organizations;
using System;
using System.Threading.Tasks;

namespace AuthHub.BLL.AuthSetting
{
    public class AuthSettingsLoader : IAuthSettingsLoader
    {

        private readonly IAuthSettingsContext _context;

        public AuthSettingsLoader(
            IAuthSettingsContext context
            )
        {
            _context = context;
        }

        public async Task<AuthSettings> ReadAsync(Guid id)
            => await _context.GetAsync(id);
    }
}
