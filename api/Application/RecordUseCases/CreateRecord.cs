using System.Threading.Tasks;
using Application.RecordDTOs;
using Domain.Entities;
using Domain.Repositories;
using Domain.Services;
using Domain.ValueObjects;

namespace Application.RecordUseCases
{
    public class CreateRecord
    {
        private readonly IRecordRepository repository;
        private readonly UserFinder finder;
        public CreateRecord(IRecordRepository recordRepository, UserFinder userFinder)
        {
            this.repository = recordRepository;
            this.finder = userFinder;
        }

        public async Task<Record> Execute(CreateRecordCommand command)
        {
            await this.finder.Find(new UserId(command.UserId));
            Record newRecord = Record.Create(command.UserId, command.Kilometers, command.CreatedAt);
            await this.repository.Save(newRecord);

            return newRecord;
        }
    }
}
