using AuthHub.Interfaces.Users;
using AuthHub.Models.Users;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AuthHub.BLL.SqlLoaders.Users
{
    public class SqlUserLoader : IUserLoader
    {
        public async Task<User> Create(Guid organizationId, string authSettingsName, User user)
        {
            throw new NotImplementedException();
        }

        public async Task<User> Get(Guid organizationId, string authSettingsName, string username)
        {
            throw new NotImplementedException();
        }

        public async Task<User> Get(UserPointer userPointer)
        {
            throw new NotImplementedException();
        }

        public async Task<User> Update(Guid organizationId, string authSettingsName, User user)
        {
            throw new NotImplementedException();
        }

        public async Task<User> Update(UserPointer pointer, User user)
        {
            throw new NotImplementedException();
        }
    }
}
