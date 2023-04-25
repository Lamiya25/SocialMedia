using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using SocialMedia.Application.Abstractions.Services;
using SocialMedia.Application.Features.Commands.Auth.FacebookLogin;
using SocialMedia.Application.Features.Commands.Auth.GoogleLogin;
using SocialMedia.Application.Features.Commands.Auth.Login;
using SocialMedia.Application.Features.Commands.Auth.RefreshTokenLogin;

namespace SocialMedia.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AuthController : ControllerBase
    {
        private readonly IMediator _mediator;

        public AuthController(IMediator mediator)
        {
            _mediator = mediator;
        }
        [HttpPost]
        public async Task<IActionResult> Login(LoginCommandRequest request)
        {
            var res = await _mediator.Send(request);
            return Ok(res);
        }


        [HttpPost("refreshToken")]
        public async Task<IActionResult> RefreshToken(RefreshTokenLoginCommandRequest request)
        {
            var res = await _mediator.Send(request);
            return Ok(res);
        }

        [HttpPost("googleLogin")]
        public async Task<IActionResult> GoogleLogin(GoogleLoginCommandRequest request)
        {
            var response = await _mediator.Send(request);
            return Ok(response);
        }

        [HttpPost("facebookLogin")]
        public async Task<IActionResult> FacebookLogin(FacebookLoginCommandRequest request)
        {
            var response = await _mediator.Send(request);
            return Ok(response);
        }

    }
}