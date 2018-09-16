using DAL;

namespace BLL.Services
{
    class BaseService
    {
        protected UnitOfWork Database { get; }

        public BaseService(string connection)
        {
            Database = new UnitOfWork(connection);
        }
    }
}
