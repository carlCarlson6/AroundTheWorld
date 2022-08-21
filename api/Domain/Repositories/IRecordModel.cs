using System;

namespace Domain.Repositories
{
    public interface IRecordModel
    {
        String id { get; set; }
        String userId { get; set; }
        Double kilometers { get; set; }
        DateTime createdAt { get; set; }
        DateTime storedAt { get; set; }
    }
}
