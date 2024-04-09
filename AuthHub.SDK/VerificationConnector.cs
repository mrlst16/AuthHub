using AuthHub.Models.Responses.Verification;
using AuthHub.SDK.Interfaces;
using AuthHub.SDK.Options;
using Common.Models.Responses;
using Microsoft.Extensions.Options;

namespace AuthHub.SDK
{
    public class VerificationConnector : ConnectorBase, IVerificationConnector
    {
        public VerificationConnector(string baseUrl, Guid authSettingsId, string apiKey, string apiSecret, Guid organizationId) : base(baseUrl, authSettingsId, apiKey, apiSecret, organizationId)
        {
        }

        public VerificationConnector(IOptions<AuthHubConnectorOptions> options)
            : base(options)
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
