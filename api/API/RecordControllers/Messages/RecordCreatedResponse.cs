using System;
using Domain.ValueObjects;

namespace API.RecordControllers.Messages
{
    public class RecordCreatedResponse
    {
        public Guid Id { get; set; }

        public RecordCreatedResponse(RecordId id)
        {
            this.Id = new Guid(id.Value);
        }
    }
}
