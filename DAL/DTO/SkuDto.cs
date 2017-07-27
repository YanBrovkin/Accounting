using System;

namespace DAL.ReadModels
{
    public class SkuReadModel
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
        public Guid DefaultPriceId { get; set; }
    }
}