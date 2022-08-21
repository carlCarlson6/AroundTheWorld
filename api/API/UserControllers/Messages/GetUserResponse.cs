using System;
using Domain.Entities;

namespace API.UserControllers.Messages
{
    public class GetUserResponse
    {
        public String Id { get; set; }
        public String Name { get; set; }

        public GetUserResponse(User user)
        {
            this.Id = user.Id.Value;
            this.Name = user.Name.Value;
        }
    }
}
