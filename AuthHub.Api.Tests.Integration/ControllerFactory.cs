using AuthHub.Api.Controllers;

namespace AuthHub.Api.Tests.Integration
{
    public static class ControllerFactory
    {

        public static UserController CreateUserController()
        {
            
            return new UserController(null, null);
        }
    }
}
