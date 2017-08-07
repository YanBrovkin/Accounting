namespace DAL.DTO
{
    public class DrWorkingDayDto
    {
        public long DocumentId { get; set; }
        public SkuDto SkuItem { get; set; }
        public int Quantity { get; set; }
        public int DiscountPercentage { get; set; }
        public string Client { get; set; }
    }
}