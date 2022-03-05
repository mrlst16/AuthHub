using AuthHub.BLL.Common.Helpers;
using AuthHub.BLL.Common.Tokens;
using AuthHub.Interfaces.Organizations;
using AuthHub.Interfaces.Passwords;
using AuthHub.Interfaces.Users;
using AuthHub.Tests.MockData;
using CommonCore.Interfaces.Helpers;
using Microsoft.Extensions.Configuration;
using NSubstitute;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Xunit;
using MockAuthSettings = AuthHub.Tests.MockData.MockAuthSettings;
using MockPasswords = AuthHub.Tests.MockData.MockPasswords;

namespace AuthHub.BLL.Common.Tests.Tokens
{
    public class JWTTokenGeneratorTests
    {
        private readonly IOrganizationLoader _organizationLoader;
        private readonly IPasswordLoader _passwordLoader;
        private readonly IUserLoader _userLoader;
        private readonly IConfiguration _configuration;
        private readonly IApplicationConsistency _applicationConsistency;

        private readonly JWTTokenGenerator _generator;

        public JWTTokenGeneratorTests()
        {
            _organizationLoader = Substitute.For<IOrganizationLoader>();
            _passwordLoader = Substitute.For<IPasswordLoader>();
            _userLoader = Substitute.For<IUserLoader>();
            _configuration = MockConfigs.Instance;
            _applicationConsistency = new ApplicationConsistency();

            _generator = new JWTTokenGenerator(
                _organizationLoader,
                _passwordLoader,
                _userLoader,
                _configuration,
                _applicationConsistency
                );
        }


        [Fact]
        public async Task GetOrganizationAuthToken_AsExpected()
        {
            var passwordRecord = MockPasswords.Instance;
            var authSettings = MockAuthSettings.AudderClients;

            _passwordLoader
                .Get(Arg.Any<Guid>(), Arg.Any<string>(), Arg.Any<string>())
                .Returns(passwordRecord);

            _organizationLoader
                .GetSettings(Arg.Any<Guid>(), Arg.Any<string>())
                .Returns(authSettings);

        }

        [Theory]
        [MemberData(nameof(PasswordsMatchData))]
        public void AuthenicateTest_PasswordsMatch(
            byte[] passwordInRepository,
            string passwordPassed,
            byte[] salt,
            int length,
            int iterations
            )
        {
            var result = _generator.Authenticate(passwordInRepository, passwordPassed, salt, length, iterations);
            Assert.True(result);
        }

        [Theory]
        [MemberData(nameof(PasswordsDoNotMatchData))]
        public void AuthenicateTest_PasswordsDoNotMatch(
          byte[] passwordInRepository,
          string passwordPassed,
          byte[] salt,
          int length,
          int iterations
          )
        {
            var result = _generator.Authenticate(passwordInRepository, passwordPassed, salt, length, iterations);
            Assert.False(result);
        }

        #region Member Data
        public static IEnumerable<object[]> PasswordsDoNotMatchData()
            => new List<object[]>
            {
                new object[] {
                    MockPasswords.PasswordHashMatty33ExclaimationPoint,
                    "Matty33!",
                    MockPasswords.CommonSalt,
                    8,
                    10
                }
            };

        public static IEnumerable<object[]> PasswordsMatchData()
            => new List<object[]>
            {
                new object[] {
                    MockPasswords.PasswordHashMatty33ExclaimationPoint,
                    "Matty31!",
                    MockPasswords.CommonSalt,
                    8,
                    10
                }
            };
        #endregion
    }
}
