using System.Data;
using System.Data.SqlClient;
using Microsoft.Extensions.Configuration;

namespace HolidayChatAgent.Repository.DbConnection
{
    public class DbConnectionFactory : IDbConnectionFactory
    {
        private readonly IConfiguration _configuration;

        public DbConnectionFactory(IConfiguration configuration)
        {
            _configuration = configuration;
        }

        public IDbConnection Create()
        {
            return new SqlConnection(_configuration.GetConnectionString("Default"));
        }
    }
}
