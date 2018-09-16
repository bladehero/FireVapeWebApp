using DAL.Identities;

namespace DAL.DAO
{
    public class ClientDao : BaseEntityDao<Client>
    {
        public ClientDao(string connectionString) : base(connectionString)
        {
            TableName = "[dbo].[Clients]";
        }
    }
}
