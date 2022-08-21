using System;
using Domain.ValueObjects;

namespace Application.RecordDTOs
{
    public class SumKilometersResult
    {
        public Double TotalSumKilometers { get; set; }
        
        public SumKilometersResult(Kilometers kilometers)
        {
            this.TotalSumKilometers = kilometers.Value;    
        }

        public SumKilometersResult(Double totalSumKilometers)
        {
            this.TotalSumKilometers = totalSumKilometers;
        }
    }
}