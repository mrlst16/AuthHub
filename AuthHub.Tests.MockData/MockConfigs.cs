using Microsoft.Extensions.Configuration;
using System.Collections.Generic;

namespace AuthHub.Tests.MockData
{
    public static class MockConfigs
    {
        public static IConfiguration Instance =>
            new ConfigurationBuilder()
                .AddInMemoryCollection(
                    new Dictionary<string, string>()
                    {
                        { "AppSettings:AuthHubOrganiztionID", "0B674AC4-7079-4AD7-830A-C41CD6AB5204"},
                        { "AppSettings:AuthHubIssuer", "Audder_Organization_Key"},
                        { "AppSettings:AuthHubKey", "this is my custom Secret key for authnetication"},
                        { "AppSettings:AuthHubSettingsId", "6CE12DA2-CB73-4F0B-B9F0-46051621B3C6"},
                        { "AppSettings:AuthHubClaimsKeys:Role", "fc77aa09-1156-4040-b0e2-72b06ba5513b"},
                        { "AppSettings:AuthHubClaimsKeys:Name", "3aacb46c-418d-4f6b-92c6-6580c473e9c6"},
                        { "AppSettings:Email:HostUrl", "https://localhost:44354"},
                        { "AppSettings:Email:ServerAddress", "smtp.gmail.com"},
                        { "AppSettings:Email:From", "mattylantz31@gmail.com"},
                        { "AppSettings:Email:Password", "Matty31!"},
                        { "AppSettings:Email:Port", "587"}
                    })
                .Build();
    }
}
