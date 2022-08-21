using System.Linq;
using System.Collections.Generic;
using System.Threading.Tasks;
using Domain.Entities;
using Domain.Services;
using Domain.ValueObjects;

namespace Application.RecordUseCases
{
    public class SumAllRecords
    {
        private readonly SumRecords sum;
        private readonly RecordFinder finder;
        public SumAllRecords(SumRecords sumRecords, RecordFinder recordFinder)
        {
            this.sum = sumRecords;
            this.finder = recordFinder;
        }

        public async Task<Kilometers> Execute()
        {
            List<Record> records = await this.finder.Find();
            List<Kilometers> kilometersList = records.Select(record => record.Kilometers).ToList();
            return this.sum.Sum(kilometersList);
        }

    }
}
