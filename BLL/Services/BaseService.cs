using BLL.Infrastructure;
using DAL;

namespace BLL.Services
{
    public class BaseService
    {
        protected UnitOfWork Database { get; }
        protected IdentityMapper IdentityMapper { get; }

        public BaseService(string connection)
        {
            Database = new UnitOfWork(connection);
            IdentityMapper = new IdentityMapper(Database);
        }
    }
}
