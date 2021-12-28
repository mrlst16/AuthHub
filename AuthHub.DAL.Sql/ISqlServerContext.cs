using System.Data;
using System.Data.SqlClient;

namespace AuthHub.DAL.Sql
{
    public interface ISqlServerContext
    {
        Task<DataSet> ReadAsync(string sproc, SqlParameter[] parameters);
    }
}
