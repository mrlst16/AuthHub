using AuthHub.BLL.Common.Helpers;
using AuthHub.BLL.Common.Tokens;
using AuthHub.Interfaces.Organizations;
using AuthHub.Interfaces.Passwords;
using AuthHub.Interfaces.Users;
using AuthHub.Tests.MockData;
using CommonCore.Interfaces.Helpers;
using FluentAssertions;
using Microsoft.Extensions.Configuration;
using NSubstitute;
using NSubstitute.ReturnsExtensions;
using System;
using System.Collections.Generic;
using System.Linq;
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
        public void GeneratePasswordHashHarness()
        {
            var result = _generator.GenerateHash("Matty33!", MockPasswords.CommonSalt, 8, 10);
            var str = result.Select(x => x.ToString()).Aggregate((x, y) => $"{x},{y}");
            //237,141,111,209,105,225,152,46,181,59
        }

        [Theory]
        [MemberData(nameof(GenerateHashData))]
        public void GenerateHash(
            string password,
            byte[] salt,
            int length,
            int iterations,
            byte[] expected
            )
        {
            var result = _generator.GenerateHash(password, salt, length, iterations);
            result.Should().BeEquivalentTo(expected);
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

        [Fact]
        public async Task Authenticate_NoLoginChallengeFound()
        {
            _passwordLoader.GetLoginChallenge(Arg.Any<Guid>(), Arg.Any<string>())
                .ReturnsNull();

            var result = await _generator.Authenticate(string.Empty, string.Empty, Guid.Empty);

            result.Should()
                .Be(false);
        }

        [Fact]
        public async Task Authenticate_LoginChallengeFound_DoesNotMatch()
        {
            _passwordLoader.GetLoginChallenge(Arg.Any<Guid>(), Arg.Any<string>())
                .Returns(MockPasswords.TestOrg1_LoginChallengeResponse);
            var authSettingsId = MockAuthSettings.TestOrganization1_AuthSettings.ID;

            var result = await _generator.Authenticate(string.Empty, string.Empty, authSettingsId);

            result.Should()
                .Be(false);
        }

        [Fact]
        public async Task Authenticate_LoginChallengeFound_Matches()
        {
            var response = MockPasswords.TestOrg1_LoginChallengeResponse;

            _passwordLoader.GetLoginChallenge(Arg.Any<Guid>(), Arg.Any<string>())
                .Returns(response);
            var authSettingsId = MockAuthSettings.TestOrganization1_AuthSettings.ID;

            var result = await _generator.Authenticate("mrlst16@mail.rmu.edu", "Matty33!", authSettingsId);

            result.Should()
                .Be(true);
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
                    MockPasswords.PasswordHash_Matty33EP_L10_I8,
                    "Matty33!",
                    MockPasswords.CommonSalt,
                    10,
                    8
                }
            };

        public static IEnumerable<object[]> GenerateHashData()
            => new List<object[]>() {
                new object[]{
                    "Matty33!",
                    MockPasswords.CommonSalt,
                    8,
                    10,
                    new byte[]{ 237, 141, 111, 209, 105, 225, 152, 46, 181, 59 }
                }
            };
        #endregion
    }
}
