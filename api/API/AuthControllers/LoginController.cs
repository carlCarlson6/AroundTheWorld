using System.Threading.Tasks;
using API.AuthControllers.Messages;
using Application.AuthDTOs;
using Application.AuthUseCases;
using Domain.ValueObjects;
using Microsoft.AspNetCore.Mvc;

namespace API.AuthControllers
{
    [ApiController]
    [Route("api/auth")]
    public class LoginController : ControllerBase
    {
        private readonly Login login;
        public LoginController(Login login) => this.login = login;

        [HttpPost]
        public async Task<UserLogedResponse> LoginUser([FromBody] LoginCommand loginCommand)
        {
            AuthToken authToken = await this.login.Execute(loginCommand);
            return new UserLogedResponse(authToken);
        }
    }
}