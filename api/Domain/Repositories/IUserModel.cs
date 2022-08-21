using System;

namespace Domain.Repositories
{
    public interface IUserModel
    {
        String id { get; set; }
        String email { get; set; }
        String name { get; set; }
        String password { get; set; }
    }
}
