using DAL.Infrastructure;

namespace DAL.Liquids
{
    public class LiquidVolumePrice : BaseEntity, ICreatorable
    {
        public int LineageId { get; set; }
        public int Volume { get; set; }
        public double Price { get; set; }
        public int CreatedBy { get; set; }
        public int ModifiedBy { get; set; }
    }
}
