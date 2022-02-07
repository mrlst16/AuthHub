using AuthHub.Models.Users;
using System.Threading.Tasks;

namespace AuthHub.SDK
{
    public interface IUserConnector
    {
        Task SaveAsync(User user);
    }
}