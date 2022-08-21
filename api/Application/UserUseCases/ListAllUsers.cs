using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Domain.Entities;
using Domain.Repositories;

namespace Application.UserUseCases
{
    public class ListAllUsers
    {
        private readonly IUserRepository repostory;
        public ListAllUsers(IUserRepository userRepostory) => this.repostory = userRepostory;

        public async Task<List<User>> Execute() => await this.repostory.Read();
        
    }
}
