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
                Id = SharedMocks.TestOrganization1Id,
                Email = "mrlst16@mail.rmu.edu",
                UserName = "mrlst16@mail.rmu.edu",
                FirstName = "Test Organization 1",
                LastName = "Test Organization 1",
                IsOrganization = true,
                UsersOrganizationId = Guid.Parse("0B674AC4-7079-4AD7-830A-C41CD6AB5204"),
                Password = new Password()
                {
                    Id = Guid.Empty,
                    Salt = SharedMocks.Salt,
                    ExpirationDate = DateTime.Parse("01/01/2022").AddHours(6).AddMinutes(30)
                }
            };
    }
}
