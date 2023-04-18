using AutoMapper;
using FluentValidation.Results;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using SocialMedia.Application.Abstractions.Services;
using SocialMedia.Application.DTOs.User;
using SocialMedia.Application.Features.Commands.User.Create;
using SocialMedia.Application.Validators;
using SocialMedia.Domain.Entities.Identity;
using SocialMedia.Persistance.Contexts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.Metadata;
using System.Text;
using System.Threading.Tasks;

namespace SocialMedia.Persistance.Services
{
    public class UserService : IUserService
    {
        private readonly UserManager<User> _userManager;
        private readonly AppDbContext _context;
        private readonly IMapper _mapper;

        public UserService(UserManager<User> userManager, AppDbContext context, IMapper mapper)
        {
            _userManager = userManager;
            _context = context;
            _mapper = mapper;
        }

        public async Task<CreateUserCommandResponse> CreateUserAsync(CreateUserDto model)
        {
            UserValidator validations = new();
            User user= _mapper.Map<User>(model);
         /*   User user = new()
            {
                Id = Guid.NewGuid().ToString(),
                FirstName = model.FirstName,
                LastName = model.LastName,
                Email = model.Email,
                UserName = model.UserName,
                Date = model.Date,
            };*/
         user.Id=Guid.NewGuid().ToString();

            ValidationResult vResults = validations.Validate(user);

            if (await IsEmailExist(user.Email))
                return new() { Succeeded = false, Errors = new() { "Email is already used" } };


           
            if (vResults.IsValid)
            {
                IdentityResult result = await _userManager.CreateAsync(user, model.Password);
                if (result.Succeeded)
                    return new() { Succeeded = true};
                return new() { Succeeded = false, Errors = result.Errors.Select(x => x.Description).ToList() };
            }
            return new() { Succeeded = false, Errors = vResults.Errors.Select(x=>x.ErrorMessage).ToList()};
        }

        private async Task<bool> IsEmailExist(string email) => await _context.Users.AnyAsync(x => x.Email == email);
    }
}
