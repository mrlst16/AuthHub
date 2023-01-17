using AuthHub.Interfaces.Users;
using AuthHub.Models.Entities.Passwords;
using AuthHub.Models.Entities.Tokens;
using AuthHub.Models.Entities.Users;
using System;
using System.Threading.Tasks;

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

        public async Task AddToken(User user, Token token)
            => await _userContext.AddToken(user, token);

        public async Task UpdatePassword(User user, Password password, PasswordArchive archives)
            => await _userContext.UpdatePassword(user, password, archives);

        public async Task Update(User user)
            => await _userContext.Update(user);
    }
}
