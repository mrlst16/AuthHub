using AuthHub.Models.Users;
using CommonCore.Interfaces.Repository;
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
