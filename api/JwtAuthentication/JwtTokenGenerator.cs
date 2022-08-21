using System.Security.Claims;
using System;
using System.IdentityModel.Tokens.Jwt;
using System.Text;
using Domain.Entities;
using Domain.Services;
using Domain.ValueObjects;
using Microsoft.IdentityModel.Tokens;
using System.Collections.Generic;

namespace JwtAuthentication
{
    public class JwtTokenGenerator : ITokenGenerator
    {
        private readonly JwtConfiguration configuration;
        public JwtTokenGenerator(JwtConfiguration jwtConfiguration)
        {
            this.configuration = jwtConfiguration;
        }

        public AuthToken GenerateToken(User user)
        {
            SymmetricSecurityKey symmetricSecurityKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(configuration.SecretKey));
            SigningCredentials signingCredentials = new SigningCredentials(symmetricSecurityKey, SecurityAlgorithms.HmacSha256);
            JwtHeader header = new JwtHeader(signingCredentials);

            List<Claim> claims = new List<Claim>
            {
                new Claim(JwtRegisteredClaimNames.Jti, Guid.NewGuid().ToString()),
                new Claim(JwtRegisteredClaimNames.NameId, user.Id.Value)
            };

            JwtPayload payload = new JwtPayload(
                issuer: configuration.Issuer,
                audience: configuration.Audience,
                claims: claims,
                notBefore: DateTime.UtcNow,
                expires: DateTime.UtcNow.AddHours(24)
            );

            JwtSecurityToken token = new JwtSecurityToken(header, payload);
            return new AuthToken(new JwtSecurityTokenHandler().WriteToken(token));
        }
    }
}
