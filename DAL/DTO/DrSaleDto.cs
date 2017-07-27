using System;

namespace DAL.DTO
{
    public class DrSaleDto
    {
        public Guid Id { get; set; }
        public Guid DocumentId { get; set; }
        public Guid SkuId { get; set; }
        public Guid PriceId { get; set; }
        public int Quantity { get; set; }
    }
}