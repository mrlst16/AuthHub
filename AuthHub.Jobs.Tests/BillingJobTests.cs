using AuthHub.Jobs.Jobs.Billing;
using AuthHub.Jobs.Models.Billing.Paypal;
using Moq;

namespace AuthHub.Jobs.Tests
{
    public class BillingJobTests
    {
        

        [Fact]
        public void Test1()
        {
            Mock<IPaypalClient> paypalClient = new Mock<IPaypalClient>();
            paypalClient.Setup(x => x.CreateDraftInvoiceAsync(Mock.Of<PaypalInvoice>()))
                .Returns(() => Task.FromResult(new CreateDraftResponse()
                {
                    Id = "INV2-TXH7-VF7J-TLKP-3N7K"
                }));
            paypalClient.Setup(x => x.SendInvoiceAsync(Mock.Of<string>()))
                .Returns(Task.FromResult(new SendInvoiceResponse()
                {
                    Href = "https://www.sandbox.paypal.com/invoice/p/#INV2-TXH7-VF7J-TLKP-3N7K"
                }));

        }

        public async Task IntegrationOnThisDate()
        {

        }
    }
}