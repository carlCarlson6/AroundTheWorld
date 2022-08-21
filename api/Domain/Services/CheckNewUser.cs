using System.Threading.Tasks;
using Domain.Entities;
using Domain.Exceptions;
using Domain.Repositories;

namespace Domain.Services
{
    public class CheckUserAlreadyExists
    {
        private readonly IUserRepository repository;
        public CheckUserAlreadyExists(IUserRepository userRepo) => this.repository = userRepo;

        public async Task Check(User user)
        {
            if(null != await this.repository.Read(user.Email))
            {
                throw new UserAlreadyExistsException(user.Email);
            }
        }
    }
}
