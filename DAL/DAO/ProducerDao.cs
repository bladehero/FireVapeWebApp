using DAL.DAO;
using DAL.Components;

namespace DAL.DAO
{
    public class ProducerDao : DAL.DAO.BaseEntityDao<Producer>
    {
        public ProducerDao(string connectionString) : base(connectionString)
        {
            TableName = "[com].[Producers]";
        }
    }
}
