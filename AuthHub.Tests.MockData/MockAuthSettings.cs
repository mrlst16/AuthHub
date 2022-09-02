using AuthHub.Models.Organizations;
using System;

namespace AuthHub.Tests.MockData
{
    public static class MockAuthSettings
    {
        public static AuthSettings AudderClients =>
            new AuthSettings()
            {
                Id = SharedMocks.AuthHubOrganization1Id,
                OrganizationID = SharedMocks.TestOrganization1Id,
                AuthScheme = Models.Enums.AuthSchemeEnum.JWT,
                ExpirationMinutes = 120,
                Iterations = 10,
                SaltLength = 8,
                HashLength = 8,
                Name = "audder_clients",
                Key = "this is my custom Secret key for authentication",
                Issuer = "Issuer",
                PasswordResetTokenExpirationMinutes = 60
            };

        public static AuthSettings TestOrganization1_AuthSettings =>
            new AuthSettings()
            {
                Id = Guid.Parse("6CE12DA2-CB73-4F0B-B9F0-46051621B3C6"),
                OrganizationID = SharedMocks.TestOrganization1Id,
                AuthScheme = Models.Enums.AuthSchemeEnum.JWT,
                ExpirationMinutes = 120,
                Iterations = 10,
                SaltLength = 8,
                HashLength = 8,
                Name = "audder_clients",
                Key = "this is my custom Secret key for authentication",
                Issuer = "Issuer",
                PasswordResetTokenExpirationMinutes = 60
            };
    }
}
