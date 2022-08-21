using System;
using Domain.ValueObjects;

namespace Domain.Entities
{
    public class Record
    {
        public RecordId Id { get; }
        public UserId UserId { get; }
        public Kilometers Kilometers { get; }
        public DateTime CreatedAt { get; }
        public DateTime StoredAt { get; }

        public Record(RecordId id, UserId userId, Kilometers kilometers, DateTime createdAt, DateTime StoredAt)
        {
            this.Id = id;
            this.UserId = userId;
            this.Kilometers = kilometers;
            this.CreatedAt = createdAt;
        }

        public static Record Create(Guid userId, Double inputKilometers, DateTime createdAt)
        {
            return new Record(new RecordId(), new UserId(userId), new Kilometers(inputKilometers), createdAt, DateTime.Today);
        }

    }
}
