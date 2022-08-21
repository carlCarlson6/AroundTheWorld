using System;

namespace Domain.ValueObjects
{
    public class UserId : EntityId
    {
        public UserId() : base() { }
        public UserId(String value) : base(value) { }
        public UserId(Guid value) : base(value) { }
    }
}
