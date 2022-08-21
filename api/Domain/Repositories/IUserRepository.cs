using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Domain.Entities;
using Domain.ValueObjects;

namespace Domain.Repositories
{
    public interface IUserRepository
    {
        Task<int> Save(User user);
        Task<User> Read(UserId id);
        Task<User> Read(Email email);
        Task<List<User>> Read();
    
    }
}
