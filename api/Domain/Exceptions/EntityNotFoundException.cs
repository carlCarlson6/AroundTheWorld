using System;

namespace Domain.Exceptions
{
    public class EntityNotFoundException : Exception
    {
        public override String Message { get => String.Format("can find the {0} with {1} = {2} ", this.entityName, this.fieldName, this.fieldValue); }
        
        private readonly String entityName;
        private readonly String fieldName;
        private readonly String fieldValue;
        
        public EntityNotFoundException(String entityName, String fieldName, String fieldValue) : base()
        {
            this.entityName = entityName;
            this.fieldName = fieldName;
            this.fieldValue = fieldValue;
        }
    }
}
