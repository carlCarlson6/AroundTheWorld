using System;

namespace Application.UserDTOs
{
    public class CreateUserCommand
    {
        public String Email { get; set; }
        public String Name { get; set; }
        public String Password { get; set; }
    }
}