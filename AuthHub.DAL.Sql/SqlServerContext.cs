using Microsoft.Extensions.Configuration;
using System.Data;
using System.Data.SqlClient;

namespace AuthHub.DAL.Sql
{
    public class SqlServerContext : ISqlServerContext
    {

        private readonly IConfiguration _config;

        public SqlServerContext(
            IConfiguration config
            )
        {
            _config = config;
        }

        public async Task<DataSet> ReadAsync(string sproc, SqlParameter[] parameters)
        {
            DataSet result = new();
            string connectionString = _config.GetConnectionString("sql");
            using (SqlConnection connection = new SqlConnection(connectionString))
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
