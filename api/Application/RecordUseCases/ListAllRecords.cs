using System.Collections.Generic;
using System.Threading.Tasks;
using Domain.Entities;
using Domain.Repositories;

namespace Application.RecordUseCases
{
    public class ListAllRecords
    {
        private readonly IRecordRepository repository;
        public ListAllRecords(IRecordRepository recordRepository) => this.repository = recordRepository;

        public async Task<List<Record>> Execute() => await this.repository.Read();

    }
}
