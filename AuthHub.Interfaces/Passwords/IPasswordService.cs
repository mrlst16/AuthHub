using AuthHub.Interfaces.Tokens;
using AuthHub.Models.Requests;
using System;
using AuthHub.Models.Entities.Passwords;

namespace AuthHub.Interfaces.Passwords
{
    public interface IPasswordService
    {
        Task<(bool, Password)> Set<T>(PasswordRequest request)
            where T : ITokenGenerator;
        Task<Password> Get(Guid organizationId, string authSettingsName, string username);

    }
}