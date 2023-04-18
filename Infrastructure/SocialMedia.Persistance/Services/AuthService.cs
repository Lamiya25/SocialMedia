using Microsoft.AspNetCore.DataProtection.AuthenticatedEncryption;
using Microsoft.AspNetCore.Identity;
using SocialMedia.Application.Abstractions.Services;
using SocialMedia.Application.Abstractions.Token;
using SocialMedia.Application.DTOs;
using SocialMedia.Application.Features.Commands.Auth.Login;
using SocialMedia.Domain.Entities.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SocialMedia.Persistance.Services
{
    public class AuthService : IAuthService
    {
        private readonly UserManager<User> _userManager;
        private readonly SignInManager<User> _signInManager;
        private readonly ITokenHandler _tokenHandler;


        public AuthService(UserManager<User> userManager, SignInManager<User> signInManager, ITokenHandler tokenHandler)
        {
            _userManager = userManager;
            _signInManager = signInManager;
            _tokenHandler = tokenHandler;
        }



        public async Task<LoginCommandResponse> LoginAsync(string emailOrusername, string password)
        {
            User user = await _userManager.FindByEmailAsync(emailOrusername);
            if (user is null)
                user = await _userManager.FindByNameAsync(emailOrusername);
            if (user is null)
            {
                return new() { Succeeded = false, Errors = new List<string> { "Username or email is incorrect" } };
            }

            SignInResult result = await _signInManager.CheckPasswordSignInAsync(user, password, false);

            if (result.Succeeded)
            {

                Token token = await _tokenHandler.CreateTokenAsync(user);
                return new() { Succeeded = true, Token = token };
            }

            return new() { Succeeded = false, Errors = new List<string> { "Password is incorrect" } }; 

        }

    }
}
