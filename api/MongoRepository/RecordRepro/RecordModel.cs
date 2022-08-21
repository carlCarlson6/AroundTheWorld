using System;
using Domain.Entities;
using Domain.Repositories;

namespace MongoRepository.RecordRepro
{
    public class RecordModel : IRecordModel
    {
        public String id { get; set; }
        public String userId { get; set; }
        public Double kilometers { get; set; }
        public DateTime createdAt { get; set; }
        public DateTime storedAt { get; set; }

        public RecordModel(Record record)
        {
            this.id = record.Id.Value;
            this.userId = record.UserId.Value;
            this.kilometers = record.Kilometers.Value;
            this.createdAt = record.CreatedAt;
            this.storedAt = record.StoredAt;
        }
    }
}
