using System;
using System.Linq;
using System.Collections.Generic;
using System.Threading.Tasks;
using Application.RecordDTOs;
using Application.RecordUseCases;
using Domain.Entities;
using Microsoft.AspNetCore.Mvc;
using Domain.ValueObjects;
using Microsoft.AspNetCore.Authorization;

namespace API.RecordControllers
{
    [ApiController]
    [Route("api/records")]
    public class GetRecordsController : ControllerBase
    {
        private readonly GetRecord get;
        private readonly ListAllRecords listAll;
        private readonly SumAllRecords sumAll;
        public GetRecordsController(GetRecord getRecord, ListAllRecords listAllRecords, SumAllRecords sumAllRecords)
        {
            this.get = getRecord;
            this.listAll = listAllRecords;
            this.sumAll = sumAllRecords;
        }

        [HttpGet]
        [AllowAnonymous]
        public async Task<IEnumerable<RecordDTO>> Get()
        {
            List<Record> records = await this.listAll.Execute();
            IEnumerable<RecordDTO> recordsDTO = records.Select(record => new RecordDTO(record));
            
            return recordsDTO;
        }

        [HttpGet("{id}")]
        [AllowAnonymous]
        public async Task<RecordDTO> Get([FromRoute] Guid id)
        {
            Record record = await this.get.Execute(id);
            return new RecordDTO(record);
        }

        [HttpGet("{id}/sum")]
        [AllowAnonymous]
        public async Task<SumKilometersResult> GetSum()
        {
            Kilometers kilometers = await this.sumAll.Execute();
            return new SumKilometersResult(kilometers);
        }
        
    }
}
