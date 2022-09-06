namespace AuthHub.BLL.Common.Exceptions
{
    public class UserNotFoundException : Exception
    {

        public UserNotFoundException()
            : base("User not found")
        {
        }

        public UserNotFoundException(Guid userId)
            : base($"User {userId} not found")
        {
        }
    }
}
