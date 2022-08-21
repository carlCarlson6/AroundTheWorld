using System;

namespace JwtAuthentication
{
    public class JwtConfiguration
    {
        public String SecretKey { get; set; }
        public String Audience { get; set; }
        public String Issuer { get; set; }
    }
}