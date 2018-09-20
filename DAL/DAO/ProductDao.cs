using DAL.Components;
using System.Collections.Generic;
using System.Linq;

namespace DAL.DAO
{
    public class ProductDao : BaseEntityDao<Product>
    {
        public ProductDao(string connectionString) : base(connectionString)
        {
            TableName = "[com].[Products]";
        }

        public IEnumerable<Product> FindByTypeId(int? id)
        {
            if (id == null)
                return null;
            return FindAll().Where(p => p.TypeId == id);
        }

        public IEnumerable<Product> FindByTypeId(Product product)
        {
            return FindByTypeId(product.Id);
        }
    }
}
