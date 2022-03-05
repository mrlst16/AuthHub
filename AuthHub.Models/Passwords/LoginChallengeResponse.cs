namespace AuthHub.Models.Passwords
{
    public class LoginChallengeResponse
    {
        public byte[] StoredPasswordHash { get; set; }
        public byte[] Salt { get; set; }
        public int Iterations { get; set; }

    }
}
