using System.Collections.Generic;
using DAL.Liquids;
using System.Linq;

namespace DAL.DAO
{
    public class LiquidDao : BaseEntityDao<Liquid>
    {
        public LiquidDao(string connectionString) : base(connectionString)
        {
            TableName = "[dbo].[Liquids]";
        }

        public IEnumerable<Liquid> FindByLineage(int? id)
        {
            if (id == null)
                return null;
            return FindAll().Where(l => l.LineageId == id);
        }
        public IEnumerable<Liquid> FindByLineage(Lineage lineage)
        {
            return FindByLineage(lineage.Id);
        }
    }
}
