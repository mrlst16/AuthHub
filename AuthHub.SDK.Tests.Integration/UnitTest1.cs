using AuthHub.Api;
using Microsoft.AspNetCore.Mvc.Testing;

namespace AuthHub.SDK.Tests.Integration
{
    public class UnitTest1
    {
        WebApplicationFactory<Program> _webApplicationFactory;

        public UnitTest1(
            WebApplicationFactory<Program> webApplicationFactory
            )
        {
            _webApplicationFactory = webApplicationFactory;
        }

        [Fact]
        public void Test1()
        {

        }
    }
}