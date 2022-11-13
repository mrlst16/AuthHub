namespace AuthHub.Interfaces.Verification
{
    public interface IVerificationCodeService
    {
        Task<string> GenerateAndSaveUserVerificationCode();
    }
}
