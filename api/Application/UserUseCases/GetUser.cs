using System.Threading.Tasks;
using Domain.Entities;
using Domain.Services;
using Domain.ValueObjects;

namespace Application.UserUseCases
{
    public class GetUser
    {
        private readonly UserFinder finder;
        public GetUser(UserFinder userFinder) => this.finder = userFinder;
        public async Task<User> Execute(UserId id) => await this.finder.Find(id);
    }
}