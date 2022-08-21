using System;

namespace Domain.Exceptions
{
    public class EmptyNullWhiteSpaceStringException : Exception
    {
        public override String Message { get => String.Format( "the input {0} is empty, null or white spaces", this.valueFieldName); }
        private readonly String valueFieldName;
        public EmptyNullWhiteSpaceStringException(String valueFieldName) : base() =>  this.valueFieldName = valueFieldName;
    }
}