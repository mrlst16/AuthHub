using AuthHub.Models.Passwords;
using AuthHub.Models.Users;
using System.Data;

namespace AuthHub.DAL.Sql.Mappers
{
    public interface IDataSetMapper
    {
        User MapUser(DataTable? table);
        Password MapPassword(DataTable? table);
        List<SerializableClaim> MapClaims(DataTable? table);
        PasswordResetToken MapPasswordResetToken(DataTable? table);
    }
}