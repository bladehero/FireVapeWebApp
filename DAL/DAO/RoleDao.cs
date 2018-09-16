using DAL.Identities;

namespace DAL.DAO
{
    public class RoleDao : BaseEntityDao<Role>
    {
        public RoleDao(string connectionString) : base(connectionString)
        {
            TableName = "[dbo].[Roles]";
        }
    }
}
