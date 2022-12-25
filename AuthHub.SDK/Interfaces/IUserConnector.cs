using AuthHub.Models.Entities.Users;

namespace AuthHub.SDK.Interfaces
{
    public interface IUserConnector
    {
        Task<User> SignUpAsync(string email, string username, string password, string firstName, string lastName);
    }
}
