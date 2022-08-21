using System;
using System.Threading.Tasks;
using Application.AuthDTOs;
using Domain.Entities;
using Domain.Services;
using Domain.ValueObjects;

namespace Application.AuthUseCases
{
    public class Login 
    {
        private readonly UserFinder finder; 
        private readonly ITokenGenerator tokenGenerator;
        public Login(UserFinder userFinder, ITokenGenerator tokenGenerator) 
        {
            this.finder = userFinder;
            this.tokenGenerator = tokenGenerator;
        }

        public async Task<AuthToken> Execute(LoginCommand command)
        {
            User user = await this.finder.Find(new Email(command.Email));
            user.Password.Verify(command.Password);
            return this.tokenGenerator.GenerateToken(user);
        }
    }
}