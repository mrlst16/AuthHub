using AuthHub.DAL.EntityFramework;
using AuthHub.Models.Entities.Users;
using Microsoft.EntityFrameworkCore;

namespace AuthHub.Api.Tests.Integration
{
    public class Tests
    {

        public Tests()
        {
            
        }

        private void Blah()
        {
            // These options will be used by the context instances in this test suite, including the connection opened above.
            
        }


        [Fact]
        public void Test1()
        {
            User user = new();
        }
    }
}