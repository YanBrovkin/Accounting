using System.Collections.Generic;

namespace Accounting.Contracts.DTO
{
    public class DHSale: DocHeader
    {
        public string Title { get; set; }
        public Buyer Buyer { get; set; }
    }

    public class DRSale : DocRow
    {
        public SKU SKU { get; set; }
        public decimal Price { get; set; }
        public int Amount { get; set; }
    }

    public class DocumentSale: Document
    {
        public DocumentSale()
        {
            this.Header = new DHSale();
            this.Rows = new List<DRSale>();
        }
        public DHSale Header { get; set; }
        public List<DRSale> Rows { get; set; }
        public decimal Discount { get; set; }
        public decimal Total { get; set; }
    }
}
