using System;
using Domain.Exceptions;

namespace Domain.ValueObjects
{
    public class Kilometers
    {
        public Double Value { get; }
        public Kilometers(Double value)
        {
            this.Validate(value);
            this.Value = value;
        }

        public void Validate(Double inputKilometers)
        {
            if(inputKilometers <= 0)
            {
                throw new InputKilometersZeroOrNegativeException();
            }
        }
    }
}
