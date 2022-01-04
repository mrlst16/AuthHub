using Microsoft.Extensions.Configuration;
using System.Data;
using System.Data.SqlClient;

namespace AuthHub.DAL.Sql
{
    public class SqlServerContext : ISqlServerContext
    {

        private readonly Func<int, IConnectionString> _connectionString;

        public SqlServerContext(
            Func<int, IConnectionString> connectionString
            )
        {
            _connectionString = connectionString;
        }

        public async Task<DataSet> ExecuteSproc(string sproc, SqlParameter[] parameters)
        {
            DataSet result = new();

            using (SqlConnection connection = new SqlConnection(_connectionString(1).Value))
            using (SqlDataAdapter sqlDataAdapter = new SqlDataAdapter())
            {
                await connection.OpenAsync();
                SqlCommand command = new SqlCommand(sproc, connection);
                sqlDataAdapter.SelectCommand = command;
                sqlDataAdapter.Fill(result);
            }
            return result;
        }

    }
}
