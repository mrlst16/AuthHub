using AuthHub.Models.Organizations;
using AuthHub.Models.Passwords;
using AuthHub.Models.Users;
using System.Data;

namespace AuthHub.DAL.Sql.Mappers
{
    public interface IDataSetMapper
    {
        User MapUser(DataTable? table);
        User MapUser(DataSet? dataSet);
        Password MapPassword(DataTable? table);
        List<Models.Passwords.ClaimsEntity> MapClaims(DataTable? table);
        PasswordResetToken MapPasswordResetToken(DataTable? table);
        List<Organization> MapOrganizations(DataTable? table);
        Organization MapOrganization(DataSet? dataSet);
        Organization MapOrganization(DataTable? table);
        AuthSettings MapAuthSettings(DataTable? table);
        AuthSettings MapAuthSettings(DataSet? dataSet);
        T MapSingle<T>(DataSet? dataSet, string columnName = "Id");
        T MapSingle<T>(DataSet? dataSet, int tableIndex, int rowIndex, string columnName = "Id");
        List<ClaimsKey> MapClaimsKeys(DataTable? table);
    }
}