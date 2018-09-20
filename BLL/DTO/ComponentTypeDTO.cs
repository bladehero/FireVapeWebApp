namespace BLL.DTO
{
    public class ComponentTypeDTO : BaseDTO, ICreatorableDTO
    {
        public string Type { get; set; }

        public ClientDTO CreatedByClient { get; set; }
        public ClientDTO ModifiedByClient { get; set; }
    }
}
