using System.Threading.Tasks;
using AuthHub.Interfaces.Billing;
using AuthHub.Models.Entities.Billing;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;

namespace AuthHub.Api.Controllers
{
    [Route("api/paypal")]
    [ApiController]
    public class PaypalController : Controller
    {
        private readonly IPaypalService _service;
        private readonly IConfiguration _configuration;
        private readonly string _webhookId;

        public PaypalController(
            IPaypalService service,
            IConfiguration configuration
        )
        {
            _service = service;
            _configuration = configuration;
            _webhookId = _configuration.GetValue<string>("");
        }

        
        [HttpPost("invoice")]
        public async Task<IActionResult> RecordInvoicePaymentAsync(
            [FromBody] PaypalWebhookEvent request
            )
        {
            //TODO: There is a verification process that should be happening here,
            //But I don't think that paypal requires it.
            //https://developer.paypal.com/api/rest/webhooks/rest/
            var transactionId = Request.Headers["paypal-transmission-id"];
            var transactionTime = Request.Headers["paypal-transmission-time"];

            await _service.RecordInvoicePaymentAsync(request);

            return Ok();
        }
    }
}