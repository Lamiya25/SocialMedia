
using SocialMedia.Application.DTOs;
using SocialMedia.Application.Features.Commands.Auth.Login;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SocialMedia.Application.Abstractions.Services
{
    public interface IAuthService
    {
        Task<LoginCommandResponse> LoginAsync(string emailOrUsername, string password);
        Task<DTOs.Token> RefreshTokenLoginAsync(string refreshToken);
        Task<DTOs.Token> GoogleLoginAsync(string idToken);
        Task<DTOs.Token> FacebookLoginAsync(string authToken);
    }
}