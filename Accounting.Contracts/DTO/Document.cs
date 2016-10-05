using System.Collections.Generic;

namespace Accounting.Contracts.DTO
{
    public class DocHeader
    {
        public long Id { get; set; }
    }

    public class DocRow
    {
        public long Id { get; set; }
    }
    public class Document
    {
        public long Id { get; set; }
        public DocHeader Header { get; set; }
        public List<DocRow> Rows { get; set; } 
    }
}
