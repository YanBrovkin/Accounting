using System;
using System.ComponentModel.DataAnnotations.Schema;

namespace DAL.DTO
{
    [Table("refPrice", Schema = "dbo")]
    public class PriceDto
    {
        public long Id { get; set; }
        public String Title { get; set; }
        public decimal Value { get; set; }
    }
}