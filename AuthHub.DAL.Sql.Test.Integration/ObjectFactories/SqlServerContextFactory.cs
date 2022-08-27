namespace AuthHub.DAL.Sql.Test.Integration.ObjectFactories
{
    internal class SqlServerContextFactory
    {
        private object _lock = new object();

        internal static SqlServerContext Instance
            => new SqlServerContext((i) => new ConnectionString(""));

    }
}
