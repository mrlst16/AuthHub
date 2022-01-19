namespace AuthHub.DAL.Sql
{
    public class ConnectionString : IConnectionString
    {
        public string Value { get; protected set; }

        public ConnectionString(
            string value
            )
        {
            Value = value;
        }

        public static implicit operator string(ConnectionString connectionString)
            => connectionString.Value;

        public static implicit operator ConnectionString(string value)
            => new ConnectionString(value);
    }
}
