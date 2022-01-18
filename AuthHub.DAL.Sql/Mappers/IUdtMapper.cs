using AuthHub.Models.Organizations;
using AuthHub.Models.Passwords;
using AuthHub.Models.Users;
using System.Data.SqlClient;

namespace AuthHub.DAL.Sql.Mappers
{
    public interface IUdtMapper
    {
        SqlParameter MapUdtClaimsKeys(IEnumerable<ClaimsKey> claims, string paramName = "@request");
        SqlParameter MapUdtClaim(Guid passwordId, IEnumerable<Models.Passwords.ClaimsEntity> claims);
        SqlParameter MapUdtUser(User user);
        SqlParameter MapUdPassword(Password password);
        SqlParameter MapUdPasswordResetToken(PasswordResetToken token);
        SqlParameter MapUdtOrganization(Organization organization);
        SqlParameter MapUdtAuthSettings(AuthSettings authSettings);
    }
}
