using AuthHub.Models.Passwords;
using AuthHub.Models.Users;
using System;

namespace AuthHub.Tests.MockData
{
    public static class MockUsers
    {
        public static User TestOrganization1 =>
            new User()
            {
                ID = SharedMocks.TestOrganization1Id,
                Email = "mrlst16@mail.rmu.edu",
                UserName = "mrlst16@mail.rmu.edu",
                FirstName = "Test Organization 1",
                LastName = "Test Organization 1",
                AuthSettingsId = Guid.Parse("6CE12DA2-CB73-4F0B-B9F0-46051621B3C6"),
                IsOrganization = true,
                UsersOrganizationId = Guid.Parse("0B674AC4-7079-4AD7-830A-C41CD6AB5204"),
                Password = new Password()
                {
                    ID = Guid.Empty,
                    Salt = SharedMocks.Salt,
                    ExpirationDate = DateTime.Parse("01/01/2022").AddHours(6).AddMinutes(30)
                }
            };
    }
}
