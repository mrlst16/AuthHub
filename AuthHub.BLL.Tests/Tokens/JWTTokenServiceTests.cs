using AuthHub.BLL.Tokens;
using AuthHub.Interfaces.Organizations;
using AuthHub.Interfaces.Passwords;
using AuthHub.Interfaces.Users;
using AuthHub.Models.Organizations;
using AuthHub.Models.Passwords;
using AuthHub.Models.Users;
using NSubstitute;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Xunit;

namespace AuthHub.BLL.Tests.Tokens
{
    public class JWTTokenServiceTests
    {
        private IOrganizationLoader _organizationLoader;
        private IUserLoader _userLoader;

        private readonly JWTTokenGenerator _service;

        public JWTTokenServiceTests()
        {
            _organizationLoader = Substitute.For<IOrganizationLoader>();
            _userLoader = Substitute.For<IUserLoader>();

            _service = new JWTTokenGenerator();
        }

        [Fact]
        public async Task CreateTokenTest()
        {
            var organizationId = Guid.Parse("98fe8d38-c783-494a-b6db-b62945530a1f");
            string settingsName = "first";

            var organizationSettings = new OrganizationSettings()
            {
                Name = settingsName,
                ExpirationMinutes = 120,
                HashLength = 8,
                Key = "this is my custom Secret key for authnetication",
                Issuer = "testissuer",
                OrganizationID = organizationId,
                TokenType = Models.Enums.TokenTypeEnum.JWT,
                Iterations = 10,
                SaltLength = 8
            };

            var passwordRequest = new PasswordRequest()
            {
                UserName = "username",
                OrganizationID = organizationId,
                Password = "testpassword",
                SettingsName = settingsName
            };

            var user = new User()
            {
                Email = "tesemail@gmail.com",
                UserName = passwordRequest.UserName,
            };

            var organization = new Organization()
            {
                ID = organizationId,
                Name = "Test Organization",
                Settings = new List<OrganizationSettings>() { organizationSettings },
                Users = new List<User>()
                {
                    user
                }
            };

            var hashResult = await _service.GetHash(passwordRequest, organization);

            var password = new Password()
            {
                Claims = new List<System.Security.Claims.Claim>()
                {
                    new System.Security.Claims.Claim("str", "val")
                },
                UserName = user.UserName,
                Salt = hashResult.Item2,
                PasswordHash = hashResult.Item1,
                HashLength = organizationSettings.HashLength,
                Iterations = organizationSettings.Iterations
            };

            user.Password = password;

            _organizationLoader
                .Get(organizationId)
                .Returns(organization);
            var actual = await _service.GetToken(passwordRequest, organization);
        }
    }
}