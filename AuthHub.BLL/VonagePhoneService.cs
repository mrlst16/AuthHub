using System.Threading.Tasks;
using AuthHub.Interfaces.Verification;
using Microsoft.Extensions.Options;
using Vonage;
using Vonage.Messaging;
using Vonage.Request;

namespace AuthHub.BLL
{

    public class VonagePhoneServiceOptions
    {
        public string FromPhoneNumber { get; set; }
        public string ApiKey { get; set; }
        public string ApiSecret { get; set; }
    }

    public class VonagePhoneService: IPhoneService
    {
        private readonly VonagePhoneServiceOptions _options;

        public VonagePhoneService(
            IOptions<VonagePhoneServiceOptions> options
            )
        {
            _options = options.Value;
        }

        public async Task SendSMSMessage(string phoneNumber, string message)
        {
            var credentials = Credentials.FromApiKeyAndSecret(_options.ApiKey, _options.ApiSecret);
            var client = new VonageClient(credentials);

            var response = await client.SmsClient.SendAnSmsAsync(new SendSmsRequest()
            {
                Text = message,
                To = phoneNumber,
                From = _options.FromPhoneNumber,
            });
        }
    }
}
