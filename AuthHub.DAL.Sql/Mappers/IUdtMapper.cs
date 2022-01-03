using AuthHub.Models.Organizations;
using AuthHub.Models.Passwords;
using AuthHub.Models.Users;
using System.Data.SqlClient;

namespace AuthHub.DAL.Sql.Mappers
{
    public interface IUdtMapper
    {
        SqlParameter MapUdtClaim(Guid passwordId, IEnumerable<SerializableClaim> claims);
        SqlParameter MapUdtUser(Guid organizationId, string authSettingsName, User user);
        SqlParameter MapUdPassword(Password password);
        SqlParameter MapUdPasswordResetToken(PasswordResetToken token);
        SqlParameter MapUdtOrganization(Organization organization);
        SqlParameter MapUdtAuthSettings(AuthSettings authSettings);
    }
}
