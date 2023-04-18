using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using SocialMedia.Application.Features.Commands.Auth.Login;
using System.Runtime.CompilerServices;

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

        [Authorize(AuthenticationSchemes="Bearer")]
        [HttpGet]
        public string sdoka()
        {
            return "yuppii";
        }
    }
}
