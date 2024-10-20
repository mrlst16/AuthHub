using AuthHub.Models.Entities.Passwords;
using System;

namespace AuthHub.Interfaces.Passwords
{
    public interface IPasswordContext
    {
        Task<(bool, Password)> Set(int organizationId, string authSettingsname, Password request);
        Task<Password> Get(int organizationId, string authSettingsname, string username);
    }
}