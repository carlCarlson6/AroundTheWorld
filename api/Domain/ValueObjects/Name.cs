using System;
using Domain.Exceptions;

namespace Domain.ValueObjects
{
    public class Name
    {
        public String Value { get; }

        public Name(String value)
        {
            this.Validate(value);
            this.Value = value;
        }

        private void Validate(String nameString)
        {
            if(String.IsNullOrEmpty(nameString) || String.IsNullOrWhiteSpace(nameString))
            {
                throw new EmptyNullWhiteSpaceStringException(nameof(Name));
            }
        }

    }
}