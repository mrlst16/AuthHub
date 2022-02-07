using AuthHub.Models.Users;
using System;
using System.Threading.Tasks;

namespace AuthHub.Interfaces.Users
{
    public interface IUserService
    {
        Task SaveAsync(User request);
        Task<UserViewModel> GetAsync(Guid id);
    }
}
