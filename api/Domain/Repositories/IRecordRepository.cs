using System.Threading.Tasks;
using Domain.Entities;
using Domain.ValueObjects;
using System.Collections.Generic;

namespace Domain.Repositories
{
    public interface IRecordRepository
    {
        Task<int> Save(Record record);
        Task<List<Record>> Read();
        Task<Record> Read(RecordId id);
        Task<List<Record>> Read(UserId id);
        
    }
}
