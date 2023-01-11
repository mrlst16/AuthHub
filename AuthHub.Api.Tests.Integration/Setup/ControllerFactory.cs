using AuthHub.Api.Controllers;
using AuthHub.BLL.Users;
using AuthHub.Interfaces.Users;

namespace AuthHub.Api.Tests.Integration.Setup
{
    public static class ControllerFactory
    {

        

        public static UserController CreateUserController()
        {
            //IUserService userService = new UserService();
            


            return new UserController(null, null);
        }
    }
}
