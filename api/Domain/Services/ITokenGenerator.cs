using Domain.Entities;
using Domain.ValueObjects;

namespace Domain.Services
{
    public interface ITokenGenerator
    {
        AuthToken GenerateToken(User user);
    }
}