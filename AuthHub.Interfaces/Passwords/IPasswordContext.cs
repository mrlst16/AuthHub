using AuthHub.Models.Passwords;
using System;
using System.Threading.Tasks;

namespace AuthHub.Interfaces.Passwords
{
    public interface IPasswordContext
    {
        Task<(bool, Password)> Set(Guid organizationId, string authSettingsname, Password request);
        Task<Password> Get(Guid organizationId, string authSettingsname, string username);
        Task<PasswordResetToken> GetPasswordResetToken(string email, Guid organizationId, string authSettingsName, DateTime expirationDate);
        Task SavePasswordResetToken(PasswordResetToken token);
    }
}