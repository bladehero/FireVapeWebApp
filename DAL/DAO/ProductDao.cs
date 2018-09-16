using DAL.DAO;
using DAL.Components;

namespace DAL.DAO
{
    public class ProductDao:BaseEntityDao<Product>
    {
        public ProductDao(string connectionString) : base(connectionString)
        {
            TableName = "[com].[Products]";
        }
    }
}
