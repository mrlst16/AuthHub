using AuthHub.DAL.EntityFramework;
using Microsoft.EntityFrameworkCore;

namespace AuthHub.Api.Tests.Integration.Setup
{
    public static class ContextFactory
    {
        public static AuthHubContext CreateContext()
        {
            var options = new DbContextOptionsBuilder<AuthHubContext>()
                .UseInMemoryDatabase("AuthHubContext")
                .Options;
            return new AuthHubContext(options);
        }
    }
}
