using Accounting.Contracts;
using Accounting.Contracts.DTO;
using Accounting.Contracts.References;
using System.Collections.Generic;

namespace Accounting.Data.References
{
    public class SKUReader : IRead<GetSKUSpecification, List<SKU>>
    {
        public List<SKU> Get(GetSKUSpecification spec)
        {
            return new List<SKU>
            {
                new SKU { Id = 1, MadeByOurOwn = true, Manufacturer = new Producer { Id = 1L, Title = @"Handcraft", LegalAddress = @"PointZero" }, Title = @"Ring" },
                new SKU { Id = 2, MadeByOurOwn = true, Manufacturer = new Producer { Id = 1L, Title = @"Handcraft", LegalAddress = @"PointZero" }, Title = @"Necklage" },
                new SKU { Id = 3, MadeByOurOwn = true, Manufacturer = new Producer { Id = 1L, Title = @"Handcraft", LegalAddress = @"PointZero" }, Title = @"Earrrings" }
            };
        }
    }
}
