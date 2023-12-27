using AuthHub.Models.Entities.Users;
using AuthHub.Models.Requests;
using AuthHub.SDK.Interfaces;
using Microsoft.Extensions.Configuration;
using System.Text;
using System.Text.Json;
using Common.Models.Responses;
using AuthHub.Models.Responses;

namespace AuthHub.SDK
{
    public class UserConnector : ConnectorBase, IUserConnector
    {
        public UserConnector(
            string baseUrl, 
            Guid authSettingsId,
            string apiKey, 
            string apiSecret,
            Guid organizationId
            ) : base(baseUrl, authSettingsId, apiKey, apiSecret, organizationId)
        {
        }

        public UserConnector(IConfiguration configuration) : base(configuration)
        {
        }

        public async Task<UserResponse> SignUpAsync(string email, string username, string password, string firstName, string lastName)
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
            return await Deserialize<UserResponse>(response);
        }

        public async Task<bool> VerifyUserEmail(Guid userId, string verificationCode)
        {
            var path = $"api/verification/user_email?userId={userId}&code={verificationCode}";
            HttpResponseMessage response = await Client.GetAsync(path);
            return await Deserialize<bool>(response);
        }
    }
}
