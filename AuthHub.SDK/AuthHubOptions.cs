using System;

namespace AuthHub.SDK
{
    public class AuthHubOptions
    {
        public const string Path = "AuthHub";

        public string Host { get; set; }
        public Guid OrganizationId { get; set; }
        public Guid AuthSettingsId { get; set; }
    }
}
