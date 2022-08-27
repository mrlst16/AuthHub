using AuthHub.BLL.Common.Helpers;
using AuthHub.BLL.Common.Tokens;
using AuthHub.Interfaces.Organizations;
using AuthHub.Interfaces.Passwords;
using AuthHub.Interfaces.Users;
using AuthHub.Models.Passwords;
using AuthHub.Tests.MockData;
using CommonCore.Interfaces.Helpers;
using CommonCore.Interfaces.Providers;
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
        private readonly IDateProvider _dateProvider;

        private readonly JWTTokenGenerator _generator;

        public JWTTokenGeneratorTests()
        {
            _organizationLoader = Substitute.For<IOrganizationLoader>();
            _passwordLoader = Substitute.For<IPasswordLoader>();
            _userLoader = Substitute.For<IUserLoader>();
            _configuration = MockConfigs.Instance;
            _applicationConsistency = new ApplicationConsistency();
            _dateProvider = Substitute.For<IDateProvider>();

            _generator = new JWTTokenGenerator(
                _organizationLoader,
                _passwordLoader,
                _userLoader,
                _configuration,
                _applicationConsistency,
                _dateProvider
                );
        }

        [Fact]
        public void GeneratePasswordHashHarness()
        {
            var result = _generator.GenerateHash("Matty33!", SharedMocks.Salt, 64, 100);
            var str = result.Select(x => x.ToString()).Aggregate((x, y) => $"{x},{y}");
        }

        [Theory]
        [MemberData(nameof(PasswordsMatchData))]
        public void GenerateHash_AsExpected(
            byte[] expected,
            string password,
            byte[] salt,
            int length,
            int iterations
            )
        {
            var result = _generator.GenerateHash(password, salt, length, iterations);
            result.Should().BeEquivalentTo(expected);
        }


        [Fact]
        public async Task GetOrganizationAuthToken_PasswordDoesNotMatch()
        {
            _passwordLoader
                .GetLoginChallenge(Guid.Empty, "mrlst16@mail.rmu.edu")
                .Returns(new LoginChallengeResponse()
                {
                    Iterations = 10,
                    Length = 8,
                    StoredPasswordHash = MockPasswords.PasswordHash_Matty33EP_L8_I10,
                    Salt = SharedMocks.Salt
                });

            await Assert.ThrowsAnyAsync<Exception>(async () => await _generator.GetTokenForAudderClients("mrlst16@mail.rmu.edu", "Matty33!"));
        }

        [Fact]
        public async Task GetOrganizationAuthToken_PasswordMatches()
        {
            string expected =
                "eyJhbGciOiJIUzI1NiIsInR5cCI6IkpXVCJ9.eyJodHRwOi8vc2NoZW1hcy54bWxzb2FwLm9yZy93cy8yMDA1LzA1L2lkZW50aXR5L2NsYWltcy9uYW1lIjoibXJsc3QxNkBtYWlsLnJtdS5lZHUiLCJleHAiOjE2NDEwNDc0MDAsImlzcyI6Iklzc3VlciIsImF1ZCI6Iklzc3VlciJ9._-OCrYWpr1-_hbeccYeuZywyEfuY11LvJEG3Sy3Gc-c";
            var loginChallengeResponse = new LoginChallengeResponse()
            {
                Iterations = 10,
                Length = 8,
                StoredPasswordHash = MockPasswords.PasswordHash_Matty33EP_L8_I10,
                Salt = SharedMocks.Salt
            };

            var authSettings = MockAuthSettings.AudderClients;

            _organizationLoader
                .GetSettings(authSettings.ID)
                .Returns(authSettings);

            var user = MockUsers.TestOrganization1;

            _passwordLoader
                .GetLoginChallenge(Arg.Any<Guid>(), Arg.Any<string>())
                .Returns(loginChallengeResponse);

            _userLoader
                .Get(authSettings.ID, Arg.Any<string>())
                .Returns(user);

            var result = await _generator.GetTokenForAudderClients("mrlst16@mail.rmu.edu", "Matty33!");
            Assert.NotNull(result);
            Assert.Equal(expected, result.Value);
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

        [Fact]
        public async Task GetToken()
        {

        }

        #region Member Data
        public static IEnumerable<object[]> PasswordsDoNotMatchData()
            => new List<object[]>
            {
                new object[] {
                    MockPasswords.PasswordHashMatty33ExclaimationPoint,
                    "Matty33!",
                    SharedMocks.Salt,
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
                    SharedMocks.Salt,
                    10,
                    8
                },
                new object[]{
                    MockPasswords.PasswordHash_Matty33EP_L8_I10,
                    "Matty33!",
                    SharedMocks.Salt,
                    8,
                    10
                },
                new object[]{
                    MockPasswords.PasswordHash_Matty33EP_L64_I100,
                    "Matty33!",
                    SharedMocks.Salt,
                    64,
                    100
                }
            };

        #endregion
    }
}
