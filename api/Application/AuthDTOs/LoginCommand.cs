using System;

namespace Application.AuthDTOs
{
    public class LoginCommand
    {
        public String Email { get; set; }
        public String Password { get; set; }
    }
}