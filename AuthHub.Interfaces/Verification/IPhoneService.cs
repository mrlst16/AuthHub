namespace AuthHub.Interfaces.Verification
{
    public interface IPhoneService
    {
        Task SendSMSMessage(string phoneNumber, string message);
    }
}
