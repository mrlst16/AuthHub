using AuthHub.Interfaces.Organizations;
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
        private readonly IOrganizationLoader _organizationLoader;
        private readonly IClaimsKeyLoader _claimsKeyLoader;

        public UserService(
            IUserLoader loader,
            IOrganizationLoader organizationLoader,
            IClaimsKeyLoader claimsKeyLoader
            )
        {
            _loader = loader;
            _organizationLoader = organizationLoader;
            _claimsKeyLoader = claimsKeyLoader;
        }

        public async Task<User> Save(UserRequest request)
        {
            var user = new User()
            {
                Email = request.Email,
                UserName = request.UserName
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
    }
}
