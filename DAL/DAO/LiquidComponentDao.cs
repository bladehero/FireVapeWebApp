using DAL.Components;
using System.Collections.Generic;
using System.Linq;

namespace DAL.DAO
{
    public class LiquidComponentDao : BaseEntityDao<LiquidComponent>
    {
        public LiquidComponentDao(string connectionString) : base(connectionString)
        {
            TableName = "[com].[LiquidComponents]";
        }

        public IEnumerable<LiquidComponent> FindByTypeId(int? id)
        {
            if (id == null)
                return null;
            return FindAll().Where(p => p.TypeId == id);
        }

        public IEnumerable<LiquidComponent> FindByTypeId(Product product)
        {
            return FindByTypeId(product.Id);
        }
    }
}
