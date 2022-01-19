using AuthHub.Models.Users;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace AuthHub.SDK
{
    public class UserConnector : IUserConnector
    {
        private readonly IApiConnector _apiConnector;

        public UserConnector(
            IApiConnector apiConnector
            )
        {
            _apiConnector = apiConnector;
        }

        public async Task<UserViewModel> GetAsync(Guid id)
            => await _apiConnector.Get<UserViewModel>("user/get",
                queryParams: new Dictionary<string, string>()
                {
                    { "id", id.ToString()}
                });

        public async Task SaveAsync(UserViewModel item)
            => await _apiConnector.Patch<UserViewModel, bool>("user/save", item);
    }
}
