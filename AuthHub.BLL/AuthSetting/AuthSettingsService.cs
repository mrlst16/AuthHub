using AuthHub.Interfaces.AuthSetting;
using AuthHub.Models.Responses.AuthSettings;
using System.Threading.Tasks;
using AuthHub.Models.Entities.Organizations;

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
                AuthScheme = response.AuthScheme,
                Key = response.Key,
                ExpirationMinutes = response.ExpirationMinutes,
                HashLength = response.HashLength,
                Issuer = response.Issuer,
                Iterations = response.Iterations,
                PasswordResetFormUrl = response.PasswordResetFormUrl,
                PasswordResetTokenExpirationMinutes = response.PasswordResetTokenExpirationMinutes,
                RequireVerification = response.RequireVerification,
                SaltLength = response.SaltLength
            };
        }
    }
}
