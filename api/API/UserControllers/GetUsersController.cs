using System;
using System.Linq;
using System.Collections.Generic;
using System.Threading.Tasks;
using Application.UserUseCases;
using Domain.Entities;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using API.UserControllers.Messages;
using Domain.ValueObjects;

namespace API.UserControllers
{
    [ApiController]
    [Route("api/users")]
    public class GetUsersController : ControllerBase
    {
        private readonly ListAllUsers allUsers;
        private readonly GetUser getUser;
        public GetUsersController(ListAllUsers allUsers, GetUser getUser)
        {
            this.allUsers = allUsers;
            this.getUser = getUser;
        }

        [HttpGet]
        [Authorize(AuthenticationSchemes = JwtBearerDefaults.AuthenticationScheme)]
        public async Task<List<GetUserResponse>> Get()
        {
            List<User> users = await allUsers.Execute(); 
            return users.Select(user => new GetUserResponse(user)).ToList();
        }

        [HttpGet("{id:guid}")]
        [AllowAnonymous]
        public async Task<GetUserResponse> Get([FromRoute] Guid id)
        {
            User user = await this.getUser.Execute(new UserId(id));
            return new GetUserResponse(user);
        }

    }
}
