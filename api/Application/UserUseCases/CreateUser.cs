using System.Threading.Tasks;
using Application.UserDTOs;
using Domain.Entities;
using Domain.Repositories;
using Domain.Services;

namespace Application.UserUseCases
{
    public class CreateUser
    {
        private readonly IUserRepository repostory;
        private readonly CheckUserAlreadyExists checkUser;
        public CreateUser(IUserRepository userRepository, CheckUserAlreadyExists checkUserAlreadyExists)
        {
            this.repostory = userRepository;
            this.checkUser = checkUserAlreadyExists;
        }

        public async Task<User> Execute(CreateUserCommand command)
        {
            User newUser = User.Create(command.Email, command.Name, command.Password);
            await this.checkUser.Check(newUser);

            await this.repostory.Save(newUser);

            return newUser; 
        }
    }
}
