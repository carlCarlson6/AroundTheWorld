
using System;
using Domain.Entities;
using Domain.Repositories;

namespace MongoRepository.UserRepo
{
    public class UserModel : IUserModel
    {
        public String id {get; set;}
        public String email {get; set;}
        public String name {get; set;}
        public String password {get; set;}

        public UserModel(User user)
        {
            this.id = user.Id.Value;
            this.email = user.Email.Value;
            this.name = user.Name.Value;
            this.password = user.Password.Value;
        }

    }
}
