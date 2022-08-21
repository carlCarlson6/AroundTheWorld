using System;
using Domain.Entities;

namespace Application.RecordDTOs
{
    public class RecordDTO
    {
        public String Id { get; set; }
        public String UserId { get; set; }
        public Double Kilometers { get; set; }
        public String CreatedAt { get; set; }

        public RecordDTO() { }

        public RecordDTO(Record record)
        {
            this.Id = record.Id.Value;
            this.UserId = record.UserId.Value;
            this.Kilometers = record.Kilometers.Value;
            this.CreatedAt = record.CreatedAt.ToString();
        } 
    }
}
