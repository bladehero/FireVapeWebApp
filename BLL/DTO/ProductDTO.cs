namespace BLL.DTO
{
    public class ProductDTO : BaseDTO, ICreatorableDTO
    {
        public string Name { get; set; }
        public ProducerDTO Producer { get; set; }
        public ComponentTypeDTO ComponentTypeDTO { get; set; }
        public double Cost { get; set; }
        public int Count { get; set; }
        public double Price { get; set; }
        public string ImageLink { get; set; }
        public string Description { get; set; }
        public ClientDTO CreatedByClient { get; set; }
        public ClientDTO ModifiedByClient { get; set; }
    }
}
