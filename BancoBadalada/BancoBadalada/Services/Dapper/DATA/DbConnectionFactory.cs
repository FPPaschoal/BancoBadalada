using Microsoft.Data.SqlClient;
using System.Data;

namespace BancoBadalada.Services.Dapper.DATA
{
    public class DbConnectionFactory : IDbConnectionFactory
    {
        private readonly IConfiguration _configuration;
        public DbConnectionFactory(IConfiguration configuration)
        {
            _configuration = configuration;
        }

        public IDbConnection CreateConnection()
        {
            string connectionString = _configuration.GetConnectionString("Thalita");
            var connection = new SqlConnection(connectionString);

            connection.Open();

            return connection;
            
        }
    }
}
