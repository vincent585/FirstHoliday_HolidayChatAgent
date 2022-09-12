using System.Data;

namespace HolidayChatAgent.Repository.DbConnection
{
    public interface IDbConnectionFactory
    {
        IDbConnection Create();
    }
}
