using AuthHub.Interfaces.Users;
using System;
using System.Threading.Tasks;
using AuthHub.Models.Entities.Users;

namespace AuthHub.BLL.Users
{
    public class UserLoader : IUserLoader
    {
        private readonly IUserContext _userContext;

        public UserLoader(
            IUserContext userContext
            )
        {
            _userContext = userContext;
        }

        public async Task<User> Create(User user)
            => await _userContext.Create(user);

        public async Task<User> GetAsync(Guid id)
            => await _userContext.GetAsync(id);

        public async Task<User> GetAsync(string username)
            => await _userContext.Get(username);

        public async Task<Guid> SaveAsync(User item)
            => await _userContext.SaveAsync(item);
    }
}
