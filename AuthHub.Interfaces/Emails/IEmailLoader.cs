using System.Threading.Tasks;

namespace AuthHub.Interfaces.Emails
{
    public interface IEmailLoader
    {
        Task SendEmail(string to, string from, string subject, string body);
    }
}