namespace BLL.DTO
{
    public class ComponentDTO : BaseDTO, ICreatorableDTO
    {
        public string Name { get; set; }
        public ProducerDTO Producer { get; set; }
        public ComponentTypeDTO ComponentType { get; set; }
        public int Count { get; set; }
        public double Cost { get; set; }
        public ClientDTO CreatedByClient { get; set; }
        public ClientDTO ModifiedByClient { get; set; }
    }
}
