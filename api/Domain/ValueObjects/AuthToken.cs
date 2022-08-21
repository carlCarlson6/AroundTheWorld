using System;

namespace Domain.ValueObjects
{
    public class AuthToken
    {
        public String Value { get; }

        public AuthToken(String tokenString)
        {
            this.Value = tokenString;
        }
    }
}
