namespace BLL.DTO
{
    class LiquidDTO
    {
        public string Name { get; set; }
        public LineageDTO Lineage { get; set; }
        public string Description { get; set; }
        public string ImageLink { get; set; }

        public ClientDTO Client { get; set; }
    }
}
