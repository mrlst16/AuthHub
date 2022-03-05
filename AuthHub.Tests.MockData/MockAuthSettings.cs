using AuthHub.Models.Organizations;
using System;

namespace AuthHub.Tests.MockData
{
    public static class MockAuthSettings
    {
        public static AuthSettings AudderClients
        {
            get => new AuthSettings()
            {
                ID = Guid.Parse("6CE12DA2-CB73-4F0B-B9F0-46051621B3C6"),
                OrganizationID = Guid.Parse("0B674AC4-7079-4AD7-830A-C41CD6AB5204"),
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
}
