using System;

namespace Application.RecordDTOs
{
    public class CreateRecordCommand
    {
        public Guid UserId { get; set; }
        public Double Kilometers { get; set; }
        public DateTime CreatedAt { get; set; }

    }
}
