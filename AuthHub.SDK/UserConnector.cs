using AuthHub.Models.Entities.Users;
using AuthHub.Models.Requests;
using AuthHub.SDK.Interfaces;
using Microsoft.Extensions.Configuration;
using System.Text;
using System.Text.Json;

namespace AuthHub.SDK
{
    internal class UserConnector : ConnectorBase, IUserConnector
    {
        public UserConnector(string baseUrl, Guid authSettingsId, string apiKey, string apiSecret) : base(baseUrl, authSettingsId, apiKey, apiSecret)
        {
        }

        public UserConnector(IConfiguration configuration) : base(configuration)
        {
        }

        public async Task<User> SignUpAsync(string email, string username, string password, string firstName, string lastName)
        {
            CreateUserRequest createUserRequest = new()
            {
                AuthSettingsID = _authSettingsId,
                FirstName = firstName,
                LastName = lastName,
                UserName = username,
                Password = password,
                Email = email
            };

            string json = JsonSerializer.Serialize(createUserRequest);
            StringContent content = new StringContent(json, Encoding.UTF8, "application/json");

            HttpResponseMessage response = await Client.PostAsync("api/user/create", content);
            string responseString = await response.Content.ReadAsStringAsync();

            User result = JsonSerializer.Deserialize<User>(responseString);
            return result;
        }
    }
}
