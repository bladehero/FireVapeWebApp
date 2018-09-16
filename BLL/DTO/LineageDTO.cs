namespace BLL.DTO
{
    class LineageDTO
    {
        public int Id { get; set; }
        public string Name { get; set; }

        public ClientDTO Client { get; set; }
    }
}
