using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Accounting.Contracts.DTO
{
    public class BuyerType
    {
        public long Id { get; set; }
        public string Title { get; set; }
    }

    public class Buyer
    {
        public long Id { get; set; }
        public string Title { get; set; }
        public BuyerType BuyerType { get; set; }
    }
}
