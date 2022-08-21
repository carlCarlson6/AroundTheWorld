using System.Threading.Tasks;
using API.UserControllers.Messages;
using Application.UserDTOs;
using Application.UserUseCases;
using Domain.Entities;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace API.UserControllers
{
    [ApiController]
    [Route("api/users")]
    public class PostUsersController : ControllerBase
    {
        private readonly CreateUser create;
        public PostUsersController(CreateUser createUser)
        {
            this.create = createUser;
        }

        [HttpPost]
        [AllowAnonymous]
        public async Task<UserCreatedResponse> Post([FromBody] CreateUserCommand createUserRequest)
        {
            User user = await this.create.Execute(createUserRequest);
            return new UserCreatedResponse(user.Id); 
        } 
    }
}
