using SocialMedia.Application.DTOs.User;
using SocialMedia.Application.Features.Commands.User.Create;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SocialMedia.Application.Abstractions.Services
{
    public interface IUserService
    {
        Task<CreateUserCommandResponse > CreateUserAsync(CreateUserDto model);
    }
}
