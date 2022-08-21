using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Domain.Entities;
using Domain.Repositories;
using Domain.Services;
using Domain.ValueObjects;

namespace Application.UserUseCases
{
    public class ListUserRecords
    {
        private readonly IRecordRepository repository;
        private readonly UserFinder finder;
        public ListUserRecords(IRecordRepository recordRepository, UserFinder userFinder)
        {
            this.repository = recordRepository;
            this.finder = userFinder;
        }

        public async Task<List<Record>> Execute(Guid userId)
        {
            UserId id = new UserId(userId);
            await this.finder.Find(id);
            
            List<Record> userRecords = await this.repository.Read(id);

            return userRecords;
        }
    }
}
