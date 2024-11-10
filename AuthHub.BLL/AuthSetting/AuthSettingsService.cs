using AuthHub.Interfaces.AuthSetting;
using AuthHub.Models.Responses.AuthSettings;
using System.Threading.Tasks;
using AuthHub.Models.Entities.Organizations;
using AuthHub.Models.Requests.AuthSettings;

namespace AuthHub.BLL.AuthSetting
{
    public class AuthSettingsService : IAuthSettingsService
    {
        private readonly IAuthSettingsContext _context;

        public AuthSettingsService(
            IAuthSettingsContext context
        )
        {
            _context = context;
        }

        public async Task<AuthSettingsResponse> GetAuthSettingsAsync(int organizationId)
        {
            AuthSettings response = await _context.GetAuthSettingsAsync(organizationId);
            return new AuthSettingsResponse()
            {
                Audience = response.Audience,
                Key = response.Key,
                ExpirationMinutes = response.ExpirationMinutes,
                HashLength = response.HashLength,
                Issuer = response.Issuer,
                Iterations = response.Iterations,
                SaltLength = response.SaltLength
            };
        }

        public async Task<bool> SaveAuthSettings(int organizationId, AuthSettingsRequest request)
            => await _context.SaveAuthSettings(organizationId, request);
    }
}