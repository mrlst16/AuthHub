using AuthHub.Interfaces.Tokens;
using AuthHub.Models.Passwords;
using AuthHub.Models.Users;
using System;
using System.Threading.Tasks;

namespace AuthHub.Interfaces.Passwords
{
    public interface IPasswordService
    {
        Task<(bool, Password)> Set<T>(PasswordRequest request)
            where T : ITokenGenerator;
        Task<Password> Get(Guid organizationId, string authSettingsName, string username);
        Task ResetOrganizationPassword(UserPointer userPointer, Guid privateToken);
        Task RequestOrganizationPasswordReset(UserPointer userPointer);
    }
}