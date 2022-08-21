using System.Linq;
using System.Collections.Generic;
using Domain.ValueObjects;
using System;
using Domain.Exceptions;

namespace Domain.Services
{
    public class SumRecords
    {
        public Kilometers Sum(List<Kilometers> kilometersList)
        {
            if(kilometersList.Count == 0)
            {
                throw new CantSumKilometersException();
            }

            Double sum = kilometersList.Sum(kilometers => kilometers.Value);
            return new Kilometers(sum);
        }
    }
}
