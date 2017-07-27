using System;

namespace DAL.ReadModels
{
    public class DocumentJournalDto
    {
        public Guid Id { get; set; }
        public int DocumentTypeId { get; set; }
        public Guid DocumentId { get; set; }
        public DateTime OperationDate { get; set; }
        public DateTime CreationDate { get; set; }
        public int Number { get; set; }
    }
}