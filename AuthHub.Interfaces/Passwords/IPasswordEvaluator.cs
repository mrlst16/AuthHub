namespace AuthHub.Interfaces.Passwords
{
    public interface IPasswordEvaluator
    {
        bool EvaluateUsernameAndPasswordWithSalt(
            string username,
            string password,
            int length,
            int iterations,
            byte[] salt,
            byte[] storedHash);
    }
}
