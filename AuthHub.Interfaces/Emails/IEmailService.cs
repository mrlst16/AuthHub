namespace AuthHub.Interfaces.Emails
{
    public interface IEmailService
    {
        Task SendEmail(string to, string subject, string body);
    }
}