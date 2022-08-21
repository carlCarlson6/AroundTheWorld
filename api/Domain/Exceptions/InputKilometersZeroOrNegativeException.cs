using System;

namespace Domain.Exceptions
{
    public class InputKilometersZeroOrNegativeException : Exception
    {
        public override String Message { get => "input kilometers can not be zero or negative"; }
    }
}
