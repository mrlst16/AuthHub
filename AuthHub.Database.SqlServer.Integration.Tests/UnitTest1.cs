using Microsoft.SqlServer.Management.Smo;
using Xunit;

namespace AuthHub.Database.SqlServer.Integration.Tests
{
    public class UnitTest1
    {

        [Fact]
        public void Test1()
        {
            try
            {
                Server server = new Server();
                var database = server.Databases["AuthHub"];
                
                
            }
            catch (System.Exception e)
            {

            }
            finally
            {
                
            }
        }
    }
}