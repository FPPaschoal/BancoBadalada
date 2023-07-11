using System.Data;

namespace BancoBadalada.Services.Dapper.DATA
{
    public interface IDbConnectionFactory
    {
        IDbConnection CreateConnection();
    }
}
