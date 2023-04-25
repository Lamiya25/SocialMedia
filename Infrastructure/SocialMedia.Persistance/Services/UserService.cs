using AutoMapper;
using FluentValidation.Results;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using SocialMedia.Application.Abstractions.Services;
using SocialMedia.Application.Consts;
using SocialMedia.Application.DTOs.User;
using SocialMedia.Application.Features.Commands.User.ChangePassword;
using SocialMedia.Application.Features.Commands.User.ChangeVisibility;
using SocialMedia.Application.Features.Commands.User.Create;
using SocialMedia.Application.Features.Commands.User.Edit;
using SocialMedia.Application.Features.Queries.User.GetAll;
using SocialMedia.Application.Features.Queries.User.GetOne;
using SocialMedia.Application.Validators;
using SocialMedia.Domain.Entities;
using SocialMedia.Domain.Entities.Identity;
using SocialMedia.Domain.Exceptions;
using SocialMedia.Persistance.Contexts;
using System.Linq.Expressions;

namespace SocialMedia.Persistance.Services
{
    public class UserService : IUserService
    {
        private readonly UserManager<User> _userManager;
        private readonly AppDbContext _context;
        private readonly IMapper _mapper;
        private readonly IPasswordValidator<User> _passwordValidator;
        private readonly IFileService _fileService;
        public UserService(UserManager<User> userManager, AppDbContext context, IMapper mapper, IPasswordValidator<User> passwordValidator, IFileService fileService)
        {
            _userManager = userManager;
            _context = context;
            _mapper = mapper;
            _passwordValidator = passwordValidator;
            _fileService = fileService;
        }

        public async Task<ChangePasswordCommandResponse> ChangePasswordAsync(string userId, string newPassword)
        {
            User? user = await _userManager.FindByIdAsync(userId);

            if (user is not null)
            {
                string newHashedPassword = _userManager.PasswordHasher.HashPassword(user, newPassword);

                user.PasswordHash = newHashedPassword;

                IdentityResult passwordResult = await _passwordValidator.ValidateAsync(_userManager, user, newPassword);

                if (passwordResult.Succeeded)
                {
                    await UpdateUserAsync(user);
                    return new() { Succeeded = true };
                }
                return new() { Succeeded = false, Errors = passwordResult.Errors.Select(x => x.Description).ToList() };

            }

            return new() { Succeeded = false };
        }

        public async Task<ChangeVisibilityCommandResponse> ChangeVisibilityAsync(string userId)
        {
            User? user = await _userManager.FindByIdAsync(userId);
            if (user is not null)
            {
                user.IsPrivate = !user.IsPrivate;
                await UpdateUserAsync(user);
                return new() { Succeeded = true };
            }
            return new() { Succeeded = false };
        }

        public async Task<CreateUserCommandResponse> CreateUserAsync(CreateUserDto model)
        {
            User user = _mapper.Map<User>(model);
            user.Id = Guid.NewGuid().ToString();
            ValidationResult vResults = await ValidateUserAsync(user);

            if (await IsEmailExist(user.Email))
                return new() { Succeeded = false, Errors = new() { Messages.UsedEmailMessage } };

            if (vResults.IsValid)
            {
                IdentityResult result = await _userManager.CreateAsync(user, model.Password);
                if (result.Succeeded)
                {
                    await AssignRoleAsync(user.Id, RoleTypes.User.ToString());
                    return new() { Succeeded = true };
                }
                return new() { Succeeded = false, Errors = result.Errors.Select(x => x.Description).ToList() };
            }

            return new() { Succeeded = false, Errors = vResults.Errors.Select(x => x.ErrorMessage).ToList() };
        }

        public async Task<EditUserCommandResponse> EditUserAsync(EditUserDto model)
        {
            User? user = await _userManager.FindByIdAsync(model.Id);
            if (user is not null)
            {
                user.FirstName = (model.FirstName ?? user.FirstName);
                user.LastName = (model.LastName ?? user.LastName);
                user.UserName = (model.UserName ?? user.UserName);
                user.About = (model.About ?? user.About);
                user.Date = model.Date;


                ValidationResult vResult = await ValidateUserAsync(user);

                if (vResult.IsValid)
                {
                    IdentityResult res = await UpdateUserAsync(user);
                    return new() { Succeeded = res.Succeeded, Errors = res.Errors.Select(x => x.Description).ToList() };
                }
                return new() { Succeeded = vResult.IsValid, Errors = vResult.Errors.Select(x => x.ErrorMessage).ToList() };

            }
            return new() { Succeeded = false };
        }

        private async Task<ValidationResult> ValidateUserAsync(User user)
        {
            UserValidator validationRules = new();
            ValidationResult result = await validationRules.ValidateAsync(user);
            return result;
        }

        public async Task UpdateRefreshTokenAsync(string refreshToken, User user, DateTime accessTokenDate, int addOnAccessTokenDate)
        {
            if (user is not null)
            {
                user.RefreshToken = refreshToken;
                user.RefreshTokenEndDate = accessTokenDate.AddMinutes(addOnAccessTokenDate);
                await _userManager.UpdateAsync(user);
            }
            else
                throw new UserNotFoundException();
        }

        private async Task<bool> IsEmailExist(string email) => await _context.Users.AnyAsync(x => x.Email == email);

        private async Task<IdentityResult> UpdateUserAsync(User user)
        {
            return await _userManager.UpdateAsync(user);
        }

        public async Task UploadProfileImageAsync(string userId, IFormFile file)
        {
            User user = await _userManager.FindByIdAsync(userId);

            ProfileImage profileImage = await _fileService.WriteProfileImageAsync(file);

            user.ProfileImageId = profileImage.Id;
            await UpdateUserAsync(user);
        }

        public async Task<bool> AssignRoleAsync(string userId, string roleTypeStr)
        {
            if (!Enum.TryParse<RoleTypes>(roleTypeStr, out RoleTypes roleType))
                return false;

            User? user = await _userManager.FindByIdAsync(userId);
            if (user is null)
                return false;

            IdentityResult res = await _userManager.AddToRoleAsync(user, roleType.ToString());
            return res.Succeeded;
        }

        public async Task<GetAllUsersQueryResponse> GetAllUsersAsync(int page = 0, int size = 5)
        {
            IEnumerable<User> users = await _context.Users.Include(x => x.ProfileImage)
                .Skip(page * size)
                .Take(size)
                .ToListAsync();


            IEnumerable<UserListDto> userList = _mapper.Map<IEnumerable<UserListDto>>(users);

            if (userList.Count() == 0)
                return new() { Succeeded = false, Errors = new List<string>() { Messages.NoUserFoundMessage } };

            return new() { Succeeded = true, Values = userList };
        }

        public async Task<GetOneUserQueryResponse> GetOneUserAsync(Expression<Func<User, bool>> filter)
        {
            User? user = await _context.Users.Include(x => x.ProfileImage).FirstOrDefaultAsync(filter);
            var finalUser = _mapper.Map<UserListDto>(user);
            if (finalUser is null)
                return new() { Succeeded = false, Errors = new List<string>() { Messages.NoUserFoundMessage } };
            return new() { Succeeded = true, Value = finalUser };
        }
    }
}
