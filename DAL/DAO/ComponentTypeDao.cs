using DAL.Components;

namespace DAL.DAO
{
    public class ComponentTypeDao : BaseEntityDao<ComponentType>
    {
        public ComponentTypeDao(string connectionString) : base(connectionString)
        {
            TableName = "[com].[ComponentTypes]";
        }
    }
}
