namespace BLL.DTO
{
    interface ICreatorableDTO
    {
        ClientDTO CreatedByClient { get; set; }
        ClientDTO ModifiedByClient { get; set; }
    }
}
