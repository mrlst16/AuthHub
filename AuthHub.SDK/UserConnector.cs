using AuthHub.Models.Entities.Users;
using AuthHub.Models.Requests;
using AuthHub.SDK.Interfaces;
using Microsoft.Extensions.Configuration;
using System.Text;
using System.Text.Json;
using Common.Models.Responses;
using AuthHub.Models.Responses.User;

namespace AuthHub.SDK
{
    public class UserConnector : ConnectorBase, IUserConnector
    {
        public UserConnector(
            string baseUrl, 
            int authSettingsId,
            string apiKey, 
            string apiSecret,
            int organizationId
            ) : base(baseUrl, authSettingsId, apiKey, apiSecret, organizationId)
        {
        }

        public UserConnector(IConfiguration configuration) : base(configuration)
        {
        } 

        public async Task<ApiResponse<UserIdResponse>> SignUpAsync(string email, string username, string password, string firstName, string lastName)
        {
            CreateUserRequest createUserRequest = new()
            {
                UserName = username,
                Password = password,
                Email = email
            };

            string json = JsonSerializer.Serialize(createUserRequest);
            StringContent content = new StringContent(json, Encoding.UTF8, "application/json");

            HttpResponseMessage response = await Client.PostAsync("api/user/create", content);
            return await Deserialize<UserIdResponse>(response);
        }

        public async Task<ApiResponse<bool>> VerifyUserEmail(int userId, string verificationCode)
        {
            var path = $"api/verification/user_email?userId={userId}&code={verificationCode}";
            HttpResponseMessage response = await Client.GetAsync(path);
            return await Deserialize<bool>(response);
        }

        public async Task<ApiResponse<UserResponse>> GetUserAsync(int userId)
        {
            var path = $"api/user?userId={userId}";
            HttpResponseMessage response = await Client.GetAsync(path);
            return await Deserialize<UserResponse>(response);
        }
    }
}
