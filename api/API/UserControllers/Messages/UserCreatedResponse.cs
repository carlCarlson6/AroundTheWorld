using System;
using Domain.ValueObjects;

namespace API.UserControllers.Messages
{
    public class UserCreatedResponse
    {
        public Guid Id { get; set; }

        public UserCreatedResponse(UserId id)
        {
            this.Id = new Guid(id.Value);
        }
    }
}
