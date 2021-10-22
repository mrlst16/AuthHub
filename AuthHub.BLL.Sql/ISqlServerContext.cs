using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AuthHub.BLL.Sql
{
    public interface ISqlServerContext
    {
        Task<DataSet> ReadAsync(string sproc, SqlParameter[] parameters);  
        Task<bool> ExecuteNonQuery(string sproc, SqlParameter[] parameters);
    }
}
