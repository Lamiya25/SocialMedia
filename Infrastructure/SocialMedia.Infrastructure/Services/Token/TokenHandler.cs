using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Tokens;
using SocialMedia.Application.Abstractions.Token;
using SocialMedia.Application.DTOs;
using SocialMedia.Domain.Entities.Identity;
using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;

namespace SocialMedia.Infrastructure.Services
{
    public class TokenHandler : ITokenHandler
    {
        private readonly IConfiguration _configuration;

        public TokenHandler(IConfiguration configuration)
        {
            _configuration = configuration;
        }

        public async Task<Token> CreateTokenAsync(User user)
        {
            Token token = new();
            //create  secutiry key's symmmetric
            SymmetricSecurityKey symmetricSecurity = new(Encoding.UTF8.GetBytes(_configuration["Token:SecurityKey"]));

          //  generate encrypted id

            SigningCredentials credentials= new(symmetricSecurity, SecurityAlgorithms.HmacSha256);

            //give the token settings to be created

            token.Expiration = DateTime.UtcNow.AddSeconds(15);

            JwtSecurityToken jwtSecurityToken = new(
                audience: _configuration["Token:Audience"], //It is the value by which we determine who/which origins/sites will use the created token value.
                issuer: _configuration["Token:Issuer"],          //It means who distributed the created token value.
                expires: token.Expiration,
                notBefore: DateTime.UtcNow,
                signingCredentials:credentials,
                claims: new List<Claim>
                {
                   new (ClaimTypes.Email, user.Email),
                   new(ClaimTypes.NameIdentifier, user.Id)
                 }
            );

            //get an instance from the token's generator class
            JwtSecurityTokenHandler tokenHandler = new();
           token.AccessToken= tokenHandler.WriteToken(jwtSecurityToken);

            return token;
        }
    }
}