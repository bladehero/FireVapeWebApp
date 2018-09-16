using DAL.Infrastructure;

namespace DAL.Components
{
    public class Producer : BaseEntity, ICreatorable
    {
        public string Name { get; set; }
        public string Country { get; set; }
        public int CreatedBy { get; set; }
        public int ModifiedBy { get; set; }
    }
}
