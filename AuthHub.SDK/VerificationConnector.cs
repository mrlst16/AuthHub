using AuthHub.Models.Entities.Users;
using AuthHub.Models.Responses.Verification;
using AuthHub.SDK.Interfaces;
using Common.Models.Responses;
using Microsoft.Extensions.Configuration;

namespace AuthHub.SDK
{
    public class VerificationConnector : ConnectorBase, IVerificationConnector
    {
        public VerificationConnector(string baseUrl, int authSettingsId, string apiKey, string apiSecret, int organizationId) : base(baseUrl, authSettingsId, apiKey, apiSecret, organizationId)
        {
        }

        public VerificationConnector(IConfiguration configuration) : base(configuration)
        {
        }

        public async Task<ApiResponse<VerificationCodeResponse>> RequestPhoneLoginCode(string phoneNumber)
        {
            var path = $"api/verification/request_phone_login_code?PhoneNumber={phoneNumber}";
            HttpResponseMessage response = await Client.GetAsync(path);
            return await Deserialize<VerificationCodeResponse>(response);
        }
    }
}
