namespace BLL.DTO
{
    public class LineageDTO : BaseDTO, ICreatorableDTO
    {
        public string Name { get; set; }
        public ClientDTO CreatedByClient { get; set; }
        public ClientDTO ModifiedByClient { get; set; }
    }
}
