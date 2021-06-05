using AuthHub.Interfaces.Users;
using AuthHub.Models.Users;
using System.Threading.Tasks;

namespace AuthHub.BLL.Users
{
    public class UserService : IUserService
    {
        private readonly IUserLoader _loader;

        public UserService(
            IUserLoader loader
            )
        {
            _loader = loader;
        }

        public async Task<User> CreateUser(UserRequest request)
        {
            var user = new User()
            {
                Email = request.Email,
                UserName = request.UserName,

            };
            return await _loader.Create(request.OrganizationID, user);
        }
    }
}
