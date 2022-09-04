using AuthHub.Interfaces.Users;
using AuthHub.Models.Users;
using System;
using System.Threading.Tasks;
using Common.Interfaces.Repository;

namespace AuthHub.BLL.Users
{
    public class UserLoader : IUserLoader
    {

        private readonly IUserContext _userContext;
        private readonly ISRDRepository<User, Guid> _usersRepository;

        public UserLoader(
            IUserContext userContext,
            ISRDRepository<User, Guid> usersRepository
            )
        {
            _userContext = userContext;
            _usersRepository = usersRepository;
        }

        public async Task<User> Create(Guid organizationId, string authSettingsName, User user)
            => await _userContext.Create(organizationId, authSettingsName, user);

        public async Task<User> Get(Guid organizationId, string authSettingsName, string username)
            => await _userContext.Get(organizationId, authSettingsName, username);

        public async Task<User> Get(UserPointer userPointer)
            => await _userContext.Get(userPointer);

        public async Task<User> Get(Guid authSettingsId, string userName)
            => await _userContext.Get(authSettingsId, userName);

        public async Task<User> GetAsync(Guid id)
            => await _userContext.GetAsync(id);

        public async Task<Guid> SaveAsync(User item)
            => await _usersRepository.SaveAsync(item);

        public async Task<User> Update(Guid organizationId, string authSettingsName, User user)
            => await _userContext.Update(organizationId, authSettingsName, user);

        public async Task<User> Update(UserPointer pointer, User user)
            => await _userContext.Update(pointer, user);
    }
}
