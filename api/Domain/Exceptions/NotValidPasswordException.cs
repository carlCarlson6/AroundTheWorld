using System;

namespace Domain.Exceptions
{
    public class NotValidPasswordException : Exception
    {
        public override String Message { get => "thi input value is not a valid password"; }
    }
}