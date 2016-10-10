using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Accounting.Contracts.DTO
{
    public class SKUGroup
    {
        public long Id { get; set; }
        public string Title { get; set; }
        public List<SKU> SKUs { get; set; }
    }
}
