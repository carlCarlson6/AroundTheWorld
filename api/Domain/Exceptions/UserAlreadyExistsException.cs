using System;
using Domain.ValueObjects;

namespace Domain.Exceptions
{
    public class UserAlreadyExistsException : Exception
    {
        public override String Message { get => String.Format("user {0} already exists", this.email.Value); }
        private readonly Email email;
        public UserAlreadyExistsException(Email userEmail) => this.email = userEmail;
    }
}
