using AuthHub.Models.Users;
using CommonCore.Interfaces.Repository;
using System.Threading.Tasks;

namespace AuthHub.Interfaces.Users
{
    public interface IUserService : ISR<UserViewModel>
    {
        Task<User> Save(UserRequest request);
    }
}
