namespace AuthHub.Models.Responses.AuthSettings
{
    public class JWTAuthSettingsResponse
    {
        public string Issuer { get; set; }
        public string Audience { get; set; }
        public string Key { get; set; }
    }
}
