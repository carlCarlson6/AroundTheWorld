using System;
using System.Threading.Tasks;
using Domain.Entities;
using Domain.Repositories;
using Domain.Services;
using Domain.ValueObjects;

namespace Application.RecordUseCases
{
    public class GetRecord
    {
        private readonly RecordFinder finder;
        public GetRecord(RecordFinder recordFinder) => this.finder = recordFinder;

        public async Task<Record> Execute(Guid recordId)
        {
            RecordId id = new RecordId(recordId);
            Record record = await this.finder.Find(id);
            return record;
        }

    }
}
