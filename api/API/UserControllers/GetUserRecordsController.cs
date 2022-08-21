using System;
using System.Linq;
using System.Collections.Generic;
using System.Threading.Tasks;
using Application.RecordDTOs;
using Application.UserUseCases;
using Domain.Entities;
using Microsoft.AspNetCore.Mvc;
using Domain.ValueObjects;
using Microsoft.AspNetCore.Authorization;

namespace API.UserControllers
{

    [ApiController]
    [Route("api/users/{id:guid}/records")]
    public class GetUserRecordsController : ControllerBase
    {
        private readonly ListUserRecords listUserRecords;
        private readonly SumUserRecords sumUserRecords;
        public GetUserRecordsController(ListUserRecords listUserRecords, SumUserRecords sumUserRecords)
        {
            this.listUserRecords = listUserRecords;
            this.sumUserRecords = sumUserRecords;
        }

        [HttpGet]
        [AllowAnonymous]
        public async Task<IEnumerable<RecordDTO>> Get([FromRoute] Guid id)
        {
            List<Record> records = await this.listUserRecords.Execute(id);
            IEnumerable<RecordDTO> recordsDTO = records.Select(record => new RecordDTO(record));

            return recordsDTO; 
        }

        [HttpGet("sum")]
        [AllowAnonymous]
        public async Task<SumKilometersResult> GetSum(Guid id)
        {
            Kilometers sumKilometers = await this.sumUserRecords.Execute(id);
            return new SumKilometersResult(sumKilometers);
        }

    }
}
