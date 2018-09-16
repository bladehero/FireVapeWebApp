using System.Data;
using System.Data.SqlClient;

namespace DAL.Infrastructure
{
    public class ConnectionFactory : IConnectionFactory
    {
        private string _connectionString;

        public ConnectionFactory(string connectionString)
        {
            _connectionString = connectionString;
        }

        public IDbConnection CreateConnection()
        {
            var connection = new SqlConnection(_connectionString);
            connection.Open();
            return connection;
        }
    }
}
