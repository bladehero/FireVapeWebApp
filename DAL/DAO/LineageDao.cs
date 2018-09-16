using DAL.Liquids;

namespace DAL.DAO
{
    public class LineageDao : BaseEntityDao<Lineage>
    {
        public LineageDao(string connectionString) : base(connectionString)
        {
            TableName = "[dbo].[Lineages]";
        }
    }
}
