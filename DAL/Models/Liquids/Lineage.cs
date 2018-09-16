using DAL.Infrastructure;

namespace DAL.Liquids
{
    public class Lineage : BaseEntity, ICreatorable
    {
        public string Name { get; set; }
        public int CreatedBy { get; set; }
        public int ModifiedBy { get; set; }
    }
}
