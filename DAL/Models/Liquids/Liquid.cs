using DAL.Infrastructure;

namespace DAL.Liquids
{
    public class Liquid : BaseEntity, ICreatorable
    {
        public string Name { get; set; }
        public int LineageId { get; set; }
        public string Description { get; set; }
        public string ImageLink { get; set; }
        public int CreatedBy { get; set; }
        public int ModifiedBy { get; set; }
    }
}