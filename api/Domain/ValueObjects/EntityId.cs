using System;

namespace Domain.ValueObjects
{
    public class EntityId
    {
        public String Value { get => this.value.ToString(); }
        private readonly Guid value;

        public EntityId()
        {
            this.value = Guid.NewGuid();
        }
        public EntityId(String value)
        {
            this.value = new Guid(value);
        }
        public EntityId(Guid value)
        {
            this.value = value;
        }
    }
}
