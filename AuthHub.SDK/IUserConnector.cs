using AuthHub.Models.Users;
using CommonCore.Interfaces.Repository;
using System.Threading.Tasks;

namespace AuthHub.SDK
{
    public interface IUserConnector
    {
        Task SaveAsync(User user);
    }
}