using AuthHub.Models.Enums;

namespace AuthHub.Models.Responses.AuthSettings
{
    public class AuthSettingsResponse
    {
        public AuthSchemeEnum AuthScheme { get; set; } = AuthSchemeEnum.JWT;
        public int SaltLength { get; set; }
        public int HashLength { get; set; }
        public int Iterations { get; set; }
        public string Key { get; set; }
        public string Issuer { get; set; }
        public string Audience { get; set; }
        public int ExpirationMinutes { get; set; } = 30;
        public int PasswordResetTokenExpirationMinutes { get; set; } = 120;
        public string PasswordResetFormUrl { get; set; }
        public bool RequireVerification { get; set; } = true;
    }
}
