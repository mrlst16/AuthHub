using AuthHub.Models.Passwords;
using System;
using System.Threading.Tasks;

namespace AuthHub.Interfaces.Passwords
{
    public interface IPasswordLoader
    {
        Task<(bool, Password)> Set(Guid organizationId, string authSettingsname, Password request);
        Task<Password> Get(Guid organizationId, string authSettingsname, string username);
    }
}