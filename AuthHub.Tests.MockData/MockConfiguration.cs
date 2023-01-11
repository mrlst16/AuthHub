using Microsoft.Extensions.Configuration;

namespace AuthHub.Tests.MockData
{
    public static class MockConfiguration
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Style", "IDE0025:Use expression body for properties", Justification = "<Pending>")]
        public static IConfiguration Instance
        {
            get => new ConfigurationBuilder()
                .AddInMemoryCollection(
                    new Dictionary<string, string>()
                    {
                        {"", ""}
                    })
                .Build();
        }
    }
}
