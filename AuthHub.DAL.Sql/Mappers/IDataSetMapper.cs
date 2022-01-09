using AuthHub.Models.Organizations;
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
        List<Organization> MapOrganizations(DataTable? table);
        Organization MapOrganization(DataSet? dataSet);
        Organization MapOrganization(DataTable? table);
        AuthSettings MapAuthSettings(DataTable? table);
        Guid MapIdFromSave(DataSet? dataSet);
    }
}