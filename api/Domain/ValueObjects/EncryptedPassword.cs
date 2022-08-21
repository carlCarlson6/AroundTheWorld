using System;

namespace Domain.ValueObjects
{
    public class EncryptedPassword
    {
        public String Value {get;}
        public EncryptedPassword(String value)
        {
            this.Value = value;
        }

    }
}
