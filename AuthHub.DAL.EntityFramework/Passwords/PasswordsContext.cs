using AuthHub.Interfaces.Passwords;
using AuthHub.Models.Entities.Passwords;

namespace AuthHub.DAL.EntityFramework.Passwords
{
    public class PasswordsContext : IPasswordContext
    {
        private readonly AuthHubContext _authHubContext;

        public PasswordsContext(
            AuthHubContext authHubContext
            )
        {
            _authHubContext = authHubContext;
        }

        public Task<(bool, Password)> Set(int organizationId, string authSettingsname, Password request)
        {
            throw new NotImplementedException();
        }

        public Task<Password> Get(int organizationId, string authSettingsname, string username)
        {
            throw new NotImplementedException();
        }
    }
}
