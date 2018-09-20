namespace BLL.DTO
{
    public class LiquidDTO : BaseDTO, ICreatorableDTO
    {
        public string Name { get; set; }
        public LineageDTO Lineage { get; set; }
        public string Description { get; set; }
        public string ImageLink { get; set; }
        public ClientDTO CreatedByClient { get; set; }
        public ClientDTO ModifiedByClient { get; set; }
    }
}
