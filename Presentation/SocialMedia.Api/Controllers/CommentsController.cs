using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Net.Http.Headers;
using SocialMedia.Application.Features.Commands.Comment.Create;
using SocialMedia.Application.Features.Commands.Comment.Delete;
using SocialMedia.Application.Features.Commands.Reply.Create;
using SocialMedia.Application.Features.Commands.Reply.Delete;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;

namespace SocialMedia.Api.Controllers
{
    [Route("api/[controller]")]
    [Authorize(AuthenticationSchemes = "Bearer")]
    [ApiController]
    public class CommentsController : ControllerBase
    {
        private readonly IMediator _mediator;
        public CommentsController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpPost]
        public async Task<IActionResult> Post(CreateCommentCommandRequest request)
        {
            var _bearer_token = Request.Headers[HeaderNames.Authorization].ToString().Replace("Bearer ", "");
            var handler = new JwtSecurityTokenHandler();
            var jwtSecurityToken = handler.ReadJwtToken(_bearer_token);
            var id = jwtSecurityToken.Claims.FirstOrDefault(x => x.Type == ClaimTypes.NameIdentifier)?.Value;

            request.CreateCommentDto.UserId = id;

            var res = await _mediator.Send(request);
            return Ok(res);
        }

        [HttpDelete]
        public async Task<IActionResult> Delete(DeleteCommentCommandRequest request)
        {
            var res = await _mediator.Send(request);
            return Ok(res);
        }


        [HttpPost("reply")]
        public async Task<IActionResult> Reply(CreateReplyCommandRequest request)
        {
            var res = await _mediator.Send(request);
            return Ok(res);
        }

        [HttpDelete("reply")]
        public async Task<IActionResult> DeleteReply(DeleteReplyCommandRequest request)
        {
            var res = await _mediator.Send(request);
            return Ok(res);
        }


    }
}