using DAL.Infrastructure;

namespace DAL.Components
{
    class LiquidComponent : BaseEntity, ICreatorable
    {
        public string Name { get; set; }
        public int? ProducerId { get; set; }
        public int TypeId { get; set; }
        public double Volume { get; set; }
        public int Count { get; set; }
        public int CreatedBy { get; set; }
        public int ModifiedBy { get; set; }
    }
}
