using AuthHub.Models.Passwords;
using AuthHub.Models.Users;
using System;
using System.Threading.Tasks;

namespace AuthHub.Interfaces.Passwords
{
    public interface IPasswordLoader
    {
        Task<(bool, Password)> Set(Guid organizationId, string authSettingsname, Password request);
        Task<Password> Get(Guid organizationId, string authSettingsname, string username);
        Task<PasswordResetToken> GeneratePasswordResetToken(UserPointer userPointer);
    }
}