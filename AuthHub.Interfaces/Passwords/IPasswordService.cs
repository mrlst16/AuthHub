using AuthHub.Interfaces.Tokens;
using AuthHub.Models.Entities.Passwords;
using AuthHub.Models.Requests;
using System;

namespace AuthHub.Interfaces.Passwords
{
    public interface IPasswordService
    {
        Task<(bool, Password)> Set<T>(PasswordRequest request)
            where T : ITokenGenerator;
        Task<Password> Get(int organizationId, string authSettingsName, string username);

    }
}