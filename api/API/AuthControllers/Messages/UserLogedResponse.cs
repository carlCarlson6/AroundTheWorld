using System;
using Domain.ValueObjects;

namespace API.AuthControllers.Messages
{
    public class UserLogedResponse
    {
        public String Token { get; set; }
        public UserLogedResponse(AuthToken authToken)
        {
            this.Token = authToken.Value;
        }
    }
}