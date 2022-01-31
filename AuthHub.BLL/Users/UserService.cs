using AuthHub.Interfaces.Passwords;
using AuthHub.Interfaces.Users;
using AuthHub.Models.Users;
using System;
using System.Threading.Tasks;

namespace AuthHub.BLL.Users
{
    public class UserService : IUserService
    {
        private readonly IUserLoader _loader;
        private readonly IClaimsKeyLoader _claimsKeyLoader;

        public UserService(
            IUserLoader loader,
            IClaimsKeyLoader claimsKeyLoader
            )
        {
            _loader = loader;
            _claimsKeyLoader = claimsKeyLoader;
        }

        public async Task<User> Save(UserRequest request)
        {
            var user = new User()
            {
                Email = request.Email,
                UserName = request.UserName,
                FirstName = request.FirstName,
                LastName = request.LastName,

            };
            return await _loader.Create(request.OrganizationID, request.SettingsName, user);
        }

        public async Task SaveAsync(UserViewModel item)
            => await _loader.Update(null, item.User);

        public async Task<UserViewModel> GetAsync(Guid id)
        {
            var user = await _loader.GetAsync(id);
            var result = new UserViewModel()
            {
                User = user,
                ClaimsKeys = await _claimsKeyLoader.GetAsync(user.AuthSettingsId)
            };
            return result;
        }

        public async Task Save(UserViewModel request)
            => await _loader.SaveAsync(request.User);

        public async Task SaveAsync(User item)
            => await _loader.SaveAsync(item);
    }
}
