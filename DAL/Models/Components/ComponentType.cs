using DAL.Infrastructure;

namespace DAL.Components
{
    public class ComponentType : BaseEntity, ICreatorable
    {
        public string Type { get; set; }
        public int CreatedBy { get; set; }
        public int ModifiedBy { get; set; }
    }
}
