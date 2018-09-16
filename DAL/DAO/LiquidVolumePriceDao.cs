using DAL.Liquids;
using System.Collections.Generic;
using System.Linq;

namespace DAL.DAO
{
    public class LiquidVolumePriceDao : BaseEntityDao<LiquidVolumePrice>
    {
        public LiquidVolumePriceDao(string connectionString) : base(connectionString)
        {
            TableName = "[dbo].[LiquidVolumePrices]";
        }

        public IEnumerable<LiquidVolumePrice> FindByLineageId(int id)
        {
            return FindAll().Where(l => l.LineageId == id);
        }
        public IEnumerable<LiquidVolumePrice> FindByLineageId(Lineage lineage)
        {
            return FindByLineageId(lineage.Id);
        }
    }
}
