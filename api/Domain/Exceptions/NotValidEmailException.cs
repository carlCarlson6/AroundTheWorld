using System;

namespace Domain.Exceptions
{
    [Serializable]
    internal class NotValidEmailException : Exception
    {
        public override String Message { get => "the input value is not a valid email"; }
    }
}