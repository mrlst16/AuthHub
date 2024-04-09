using AuthHub.Models.Requests;
using AuthHub.Models.Responses.User;
using AuthHub.SDK.Interfaces;
using AuthHub.SDK.Options;
using Common.Models.Responses;
using Microsoft.Extensions.Options;
using System.Text;
using System.Text.Json;

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

        public UserConnector(IOptions<AuthHubConnectorOptions> options)
            : base(options)
        {
        }

        public async Task<ApiResponse<UserIdResponse>> SignUpAsync(string email, string username, string password, string firstName, string lastName)
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
            return await Deserialize<UserIdResponse>(response);
        }

        public async Task<ApiResponse<bool>> VerifyUserEmail(Guid userId, string verificationCode)
        {
            var path = $"api/verification/user_email?userId={userId}&code={verificationCode}";
            HttpResponseMessage response = await Client.GetAsync(path);
            return await Deserialize<bool>(response);
        }

        public async Task<ApiResponse<UserResponse>> GetUserAsync(Guid userId)
        {
            var path = $"api/user?userId={userId}";
            HttpResponseMessage response = await Client.GetAsync(path);
            return await Deserialize<UserResponse>(response);
        }
    }
}
