using System.Data;

namespace DAL.Infrastructure
{
    public interface IConnectionFactory
    {
        IDbConnection CreateConnection();
    }
}
