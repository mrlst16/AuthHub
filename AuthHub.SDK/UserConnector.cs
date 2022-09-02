using AuthHub.Models.Users;
using System.Threading.Tasks;

namespace AuthHub.SDK
{
    public class UserConnector : IUserConnector
    {
        private readonly IApiConnector _apiConnector;

        public UserConnector(
            IApiConnector apiConnector
            )
        {
            _apiConnector = apiConnector;
        }

        public async Task SaveAsync(SaveUserRequest item)
            => await _apiConnector.Patch<SaveUserRequest, bool>("user/save", item);

    }
}
