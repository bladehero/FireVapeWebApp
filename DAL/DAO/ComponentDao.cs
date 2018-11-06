using DAL.Components;
using System.Collections.Generic;
using System.Linq;

namespace DAL.DAO
{
    public class ComponentDao : BaseEntityDao<Component>
    {
        public ComponentDao(string connectionString) : base(connectionString)
        {
            TableName = "[com].[Components]";
        }

        public IEnumerable<Component> FindByTypeId(int? id)
        {
            if (id == null)
                return null;
            return FindAll().Where(p => p.TypeId == id);
        }

        public IEnumerable<Component> FindByTypeId(Product product)
        {
            return FindByTypeId(product.Id);
        }
    }
}
