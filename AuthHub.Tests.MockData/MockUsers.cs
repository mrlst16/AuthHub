using AuthHub.Models.Users;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AuthHub.Tests.MockData
{
    public static class MockUsers
    {
        public static User TestOrganization1
        {
            get => new User()
            {
                ID = Guid.Parse("618899E7-CA5B-4809-9D5F-64548C18FAD3"),
                Email = "mrlst16@mail.rmu.edu",
                UserName = "mrlst16@mail.rmu.edu",
                FirstName = "Test Organization 1",
                LastName = "Test Organization 1",
                AuthSettingsId = Guid.Parse("6CE12DA2-CB73-4F0B-B9F0-46051621B3C6"),
                IsOrganization = true,
                UsersOrganizationId = Guid.Parse("0B674AC4-7079-4AD7-830A-C41CD6AB5204")
            };
        }
    }
}
