using AuthHub.Interfaces.Users;
using AuthHub.Models.Users;

namespace AuthHub.DAL.EntityFramework.Users
{
    public class UserContext : IUserContext
    {
        public Task<User> Create(Guid organizationId, string authSettingsName, User user)
        {
            throw new NotImplementedException();
        }

        public Task<User> Get(Guid organizationId, string authSettingsName, string username)
        {
            throw new NotImplementedException();
        }

        public Task<User> Get(UserPointer userPointer)
        {
            throw new NotImplementedException();
        }

        public Task<User> Update(Guid organizationId, string authSettingsName, User user)
        {
            throw new NotImplementedException();
        }

        public Task<User> Update(UserPointer pointer, User user)
        {
            throw new NotImplementedException();
        }

        public Task<User> GetAsync(Guid id)
        {
            throw new NotImplementedException();
        }

        public Task SaveAsync(User item)
        {
            throw new NotImplementedException();
        }

        public Task<User> Get(Guid authSettingsId, string userName)
        {
            throw new NotImplementedException();
        }
    }
}
