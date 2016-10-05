namespace Accounting.Contracts.DTO
{
    public class SKU
    {
        public long Id { get; set; }
        public string Title { get; set; }
        public bool MadeByOurOwn { get; set; }
        public Producer Manufacturer { get; set; }
    }
}
