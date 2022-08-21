using System;

namespace Domain.ValueObjects
{
    public class RecordId : EntityId
    {
        public RecordId() : base() { }
        public RecordId(String value) : base(value) { }
        public RecordId(Guid value) : base(value) { }
    }
}
