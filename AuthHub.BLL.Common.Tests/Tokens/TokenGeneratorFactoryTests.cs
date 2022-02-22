using AuthHub.Interfaces.Organizations;
using AuthHub.Interfaces.Passwords;
using AuthHub.Interfaces.Users;
using Microsoft.Extensions.Configuration;
using NSubstitute;
using System.Collections.Generic;
using System.Threading.Tasks;
using Xunit;

namespace AuthHub.BLL.Common.Tests.Tokens
{
    public class TokenGeneratorFactoryTests
    {
        private readonly IOrganizationLoader _organizationLoader;
        private readonly IPasswordLoader _passwordLoader;
        private readonly IUserLoader _userLoader;
        private readonly IConfiguration _configuration;

        public TokenGeneratorFactoryTests()
        {
            _organizationLoader = Substitute.For<IOrganizationLoader>();
            _passwordLoader = Substitute.For<IPasswordLoader>();
            _userLoader = Substitute.For<IUserLoader>();
            _configuration = Substitute.For<IConfiguration>();

            var config = new ConfigurationBuilder()
                .AddInMemoryCollection(new Dictionary<string, string>()
                {
                    { "", ""}
                }).Build();

        }

        [Fact]
        public async Task T()
        {

        }
    }
}
