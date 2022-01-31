using AuthHub.Models.Users;
using CommonCore.Interfaces.Repository;

namespace AuthHub.SDK
{
    public interface IUserConnector : IEntityInViewModelOut<User, UserViewModel>
    {
    }
}
