using AuthHub.Models.Users;
using System.Threading.Tasks;

namespace AuthHub.Interfaces.Users
{
    public interface IUserService
    {
        Task<User> CreateUser(UserRequest request);
    }
}
