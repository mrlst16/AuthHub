﻿using AuthHub.BLL.Common.Tokens;
using AuthHub.Interfaces.Organizations;
using AuthHub.Interfaces.Passwords;
using AuthHub.Interfaces.Users;
using AuthHub.Models.Organizations;
using AuthHub.Models.Passwords;
using AuthHub.Models.Users;
using Microsoft.Extensions.Configuration;
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
        private IPasswordLoader _passwordLoader;
        private IConfiguration _configuration;

        private readonly JWTTokenGenerator _generator;

        public JWTTokenServiceTests()
        {
            _organizationLoader = Substitute.For<IOrganizationLoader>();
            _userLoader = Substitute.For<IUserLoader>();
            _passwordLoader = Substitute.For<IPasswordLoader>();
            _configuration = Substitute.For<IConfiguration>();

            _generator = new JWTTokenGenerator(
                _organizationLoader,
                _passwordLoader,
                _userLoader,
                _configuration
                );
        }

        [Fact]
        public async Task CreateTokenTest()
        {
            var organizationId = Guid.Parse("98fe8d38-c783-494a-b6db-b62945530a1f");
            string settingsName = "first";
            string username = "username";

            var user = new User()
            {
                Email = "tesemail@gmail.com",
                UserName = username
            };

            var organizationSettings = new AuthSettings()
            {
                Name = settingsName,
                ExpirationMinutes = 120,
                HashLength = 8,
                Key = "this is my custom Secret key for authnetication",
                Issuer = "testissuer",
                OrganizationID = organizationId,
                AuthScheme = Models.Enums.AuthSchemeEnum.JWT,
                Iterations = 10,
                SaltLength = 8,
                Users = new List<User>()
                {
                    user
                }
            };

            var passwordRequest = new PasswordRequest()
            {
                UserName = username,
                OrganizationID = organizationId,
                Password = "testpassword",
                SettingsName = settingsName
            };


            var organization = new Organization()
            {
                ID = organizationId,
                Name = "Test Organization",
                Settings = new List<AuthSettings>() { organizationSettings },
            };

            var hashResult = await _generator.GetHash(passwordRequest, organization);

            var password = new Password()
            {
                Claims = new List<ClaimsEntity>()
                {
                    new ClaimsEntity("str", "val", Guid.Parse("841e15bc-ab6d-4220-b6fd-08349238e456"))
                },
                UserName = username,
                Salt = hashResult.Item2,
                PasswordHash = hashResult.Item1,
                HashLength = organizationSettings.HashLength,
                Iterations = organizationSettings.Iterations
            };

            user.Password = password;

            _organizationLoader
                .Get(organizationId)
                .Returns(organization);

            _passwordLoader
                .Get(Arg.Any<Guid>(), Arg.Any<string>(), Arg.Any<string>())
                .Returns(password);

            _organizationLoader
                .GetSettings(Arg.Any<Guid>(), Arg.Any<string>())
                .Returns(organizationSettings);

            var actual = await _generator.GetToken(passwordRequest, organization);
        }
    }
}