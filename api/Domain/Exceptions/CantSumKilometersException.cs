using System;

namespace Domain.Exceptions
{
    public class CantSumKilometersException : Exception
    {
        public override String Message { get => "can not sum the records, the list is empty"; }

        public CantSumKilometersException() : base() { }
    }
}
