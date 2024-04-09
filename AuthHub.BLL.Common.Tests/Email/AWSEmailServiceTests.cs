using AuthHub.BLL.Common.Emails;
using AuthHub.Models.Options;
using Microsoft.Extensions.Options;
using Moq;
using System.Threading.Tasks;
using Xunit;

namespace AuthHub.BLL.Common.Tests.Email
{
    public class AWSEmailServiceTests
    {
        private readonly AWSEmailService _service;

        public AWSEmailServiceTests()
        {
            var options = Mock.Of<IOptions<EmailServiceOptions>>();

        }

        [Fact]
        public async Task SendEmail()
        {
            await _service.SendEmail("", "", "");
        }
    }
}
