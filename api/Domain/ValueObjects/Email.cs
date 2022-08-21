using System.Net.Mail;
using System;
using Domain.Exceptions;

namespace Domain.ValueObjects
{
    public class Email
    {
        public String Value {get;}

        public Email(String value) 
        {
            this.Validate(value);
            this.Value = value;
        }

        private void Validate(String emailString)
        {
            if(String.IsNullOrEmpty(emailString) || String.IsNullOrWhiteSpace(emailString))
            {
                throw new EmptyNullWhiteSpaceStringException(nameof(Email));
            }

            MailAddress address = new MailAddress(emailString);
            if(emailString != address.Address)
            {
                throw new NotValidEmailException();
            }

        }
    }
}
