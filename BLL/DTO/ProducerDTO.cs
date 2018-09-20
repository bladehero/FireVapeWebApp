namespace BLL.DTO
{
    public class ProducerDTO : BaseDTO, ICreatorableDTO
    {
        public string Name { get; set; }
        public string Country { get; set; }
        public ClientDTO Client { get; set; }
        public ClientDTO CreatedByClient { get; set; }
        public ClientDTO ModifiedByClient { get; set; }
    }
}
