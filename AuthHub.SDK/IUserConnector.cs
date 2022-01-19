using AuthHub.Models.Users;
using CommonCore.Interfaces.Repository;

namespace AuthHub.SDK
{
    public interface IUserConnector : ISR<UserViewModel>
    {
    }
}
