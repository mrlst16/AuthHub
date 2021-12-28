using System.Data;
using System.Data.SqlClient;

namespace AuthHub.BLL.Sql
{
    public interface ISqlServerContext
    {
        Task<DataSet> ReadAsync(string sproc, SqlParameter[] parameters);
    }
}
