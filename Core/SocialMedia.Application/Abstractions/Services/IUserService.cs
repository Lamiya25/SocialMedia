using Microsoft.AspNetCore.Http;
using SocialMedia.Application.DTOs.User;
using SocialMedia.Application.Features.Commands.User.ChangePassword;
using SocialMedia.Application.Features.Commands.User.ChangeVisibility;
using SocialMedia.Application.Features.Commands.User.Create;
using SocialMedia.Application.Features.Commands.User.Edit;
using SocialMedia.Application.Features.Queries.User.GetAll;
using SocialMedia.Application.Features.Queries.User.GetOne;
using SocialMedia.Domain.Entities.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace SocialMedia.Application.Abstractions.Services
{
    public interface IUserService
    {
        Task<CreateUserCommandResponse> CreateUserAsync(CreateUserDto model);
        Task UpdateRefreshTokenAsync(string refreshToken, User user, DateTime accessTokenDate, int addOnAccessTokenDate);
        Task<ChangePasswordCommandResponse> ChangePasswordAsync(string userId, string newPassword);
        Task<ChangeVisibilityCommandResponse> ChangeVisibilityAsync(string userId);
        Task<EditUserCommandResponse> EditUserAsync(EditUserDto model);
        Task UploadProfileImageAsync(string userId, IFormFile file);
        Task<bool> AssignRoleAsync(string userId, string roleTypeStr);
        Task<GetAllUsersQueryResponse> GetAllUsersAsync(int page = 0, int size = 5);
        Task<GetOneUserQueryResponse> GetOneUserAsync(Expression<Func<User, bool>> filter);
    }
}