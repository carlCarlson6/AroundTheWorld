using System;

namespace Domain.Exceptions
{
    public class PasswordDoesNotMatchException : Exception
    {
        public override String Message { get => "input password does not match"; }
    }
}