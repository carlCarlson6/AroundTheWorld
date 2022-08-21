using System.Collections.Generic;
using System.Threading.Tasks;
using Domain.Entities;
using Domain.Exceptions;
using Domain.Repositories;
using Domain.ValueObjects;

namespace Domain.Services
{
    public class RecordFinder
    {
        private readonly IRecordRepository repo;
        public RecordFinder(IRecordRepository recordRepo) => this.repo = recordRepo;

        public async Task<List<Record>> Find()
        {
            List<Record> records = await this.repo.Read();
            if(records.Count == 0)
            {
                throw new EntitiesNotFoundException(nameof(Record));
            }
            return records;
        }

        public async Task<Record> Find(RecordId id)
        {
            Record record = await this.repo.Read(id);
            if(record == null)
            {
                throw new EntityNotFoundException(nameof(Record), nameof(RecordId), id.Value);
            }
            return record;
        }

        public async Task<List<Record>> Find(UserId id)
        {
            List<Record> records = await this.repo.Read(id);
            if(records.Count == 0)
            {
                throw new EntitiesNotFoundException(nameof(Record));
            }
            return records;
        }

    }
}
