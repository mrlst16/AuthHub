namespace AuthHub.Models.Requests
{
    public class LoginChallengeResponse
    {
        public byte[] StoredPasswordHash { get; set; }
        public byte[] Salt { get; set; }
        public int Iterations { get; set; }
        public int Length { get; set; }
    }
}
