using AuthHub.Models.Users;
using CommonCore.Interfaces.Repository;

namespace AuthHub.Interfaces.Users
{
    public interface IUserService : IEntityInViewModelOut<User, UserViewModel>
    {
    }
}
