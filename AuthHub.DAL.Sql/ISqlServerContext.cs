using System.Data;
using System.Data.SqlClient;

namespace AuthHub.DAL.Sql
{
    public interface ISqlServerContext
    {
        Task<DataSet> ExecuteSproc(string sproc, params SqlParameter[] parameters);
        Task<DataSet> ExecuteSproc(string sproc);
    }
}
