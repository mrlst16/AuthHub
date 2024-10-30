namespace AuthHub.Models.Options
{
    public class OrganizationsAuthOptions
    {
        public string Key { get; set; }
        public double ExpirationMinutes { get; set; }
        public string Issuer { get; set; }
        public string Audience { get; set; }
    }
}
