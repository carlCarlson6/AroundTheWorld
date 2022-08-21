using System;

namespace Domain.Exceptions
{
    public class EntitiesNotFoundException : Exception
    {
        public override String Message { get => String.Format("no {0} was found", this.entityName); }
        
        private readonly String entityName;

        public EntitiesNotFoundException(String entityName) : base()
        {
            this.entityName = entityName;
        }
    }
}
