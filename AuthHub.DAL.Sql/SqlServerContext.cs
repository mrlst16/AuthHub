using CommonCore2.Extensions;
using Microsoft.Extensions.Configuration;
using System.Data;
using System.Data.SqlClient;

namespace AuthHub.DAL.Sql
{
    public class SqlServerContext : ISqlServerContext
    {

        private readonly Func<int, IConnectionString> _connectionStringFactory;

        public SqlServerContext(
            Func<int, IConnectionString> connectionStringFactory
            )
        {
            _connectionStringFactory = connectionStringFactory;
        }

        public async Task<DataSet> ExecuteSproc(string sproc, SqlParameter[] parameters)
        {
            DataSet result = new();
            try
            {
                IConnectionString connectionString = _connectionStringFactory(2);
#if DEBUG
                var sql = parameters.ToSqlString($"exec {sproc}");
#endif
                using (SqlConnection connection = new SqlConnection(connectionString.Value))
                using (SqlDataAdapter sqlDataAdapter = new SqlDataAdapter($"{sproc}", connection))
                {
                    await connection.OpenAsync();
                    sqlDataAdapter.SelectCommand.CommandType = CommandType.StoredProcedure;
                    sqlDataAdapter.SelectCommand.Parameters.AddRange(parameters);
                    sqlDataAdapter.Fill(result);
                }
            }
            catch (Exception e)
            {

                throw;
            }
            return result;
        }

        public async Task<DataSet> ExecuteSproc(string sproc)
        {
            DataSet result = new();
            try
            {
                IConnectionString connectionString = _connectionStringFactory(2);

                using (SqlConnection connection = new SqlConnection(connectionString.Value))
                using (SqlDataAdapter sqlDataAdapter = new SqlDataAdapter($"{sproc}", connection))
                {
                    await connection.OpenAsync();
                    sqlDataAdapter.SelectCommand.CommandType = CommandType.StoredProcedure;
                    sqlDataAdapter.Fill(result);
                }
            }
            catch (Exception e)
            {

                throw;
            }
            return result;
        }
    }
}
