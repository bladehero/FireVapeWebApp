namespace DAL.Infrastructure
{
    interface ICreatorable
    {
        int CreatedBy { get; set; }
        int ModifiedBy { get; set; }
    }
}
