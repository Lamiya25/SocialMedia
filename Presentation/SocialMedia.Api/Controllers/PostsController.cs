using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Net.Http.Headers;
using SocialMedia.Application.Features.Commands.Post.Archive;
using SocialMedia.Application.Features.Commands.Post.Create;
using SocialMedia.Application.Features.Commands.Post.Delete;
using SocialMedia.Application.Features.Commands.Post.DeletePostImage;
using SocialMedia.Application.Features.Commands.Post.Edit;
using SocialMedia.Application.Features.Commands.PostReaction;

using SocialMedia.Application.Features.Queries.Post.GetAll;

using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Security.Permissions;

namespace SocialMedia.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [Authorize(AuthenticationSchemes = "Bearer")]
    public class PostsController : ControllerBase
    {
        private readonly IMediator _mediator;
        public PostsController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpPost]
        public async Task<IActionResult> Post([FromForm] PostCreateCommandRequest request)
        {
            var _bearer_token = Request.Headers[HeaderNames.Authorization].ToString().Replace("Bearer ", "");
            var handler = new JwtSecurityTokenHandler();
            var jwtSecurityToken = handler.ReadJwtToken(_bearer_token);
            var id = jwtSecurityToken.Claims.FirstOrDefault(x => x.Type == ClaimTypes.NameIdentifier)?.Value;

            request.CreatePostDto.UserId = id;

            var res = await _mediator.Send(request);
            return Ok(res);
        }

        [HttpPut]
        public async Task<IActionResult> Put([FromForm] EditPostCommandRequest request)
        {
            var res = await _mediator.Send(request);
            return Ok(res);
        }

        [HttpDelete("deletePostImage")]
        public async Task<IActionResult> DeletePostImage(DeletePostImageCommandRequest request)
        {
            var res = await _mediator.Send(request);
            return Ok(res);
        }

        [HttpDelete("delete")]
        public async Task<IActionResult> Delete(DeletePostCommandRequest request)
        {
            var res = await _mediator.Send(request);
            return Ok(res);
        }

        [HttpPut("archive")]
        public async Task<IActionResult> Archive(ArchivePostCommandRequest request)
        {
            var res = await _mediator.Send(request);
            return Ok(res);
        }

        [HttpPost("like")]
        public async Task<IActionResult> Like(LikePostCommandRequest request)
        {
            var _bearer_token = Request.Headers[HeaderNames.Authorization].ToString().Replace("Bearer ", "");
            var handler = new JwtSecurityTokenHandler();
            var jwtSecurityToken = handler.ReadJwtToken(_bearer_token);
            var id = jwtSecurityToken.Claims.FirstOrDefault(x => x.Type == ClaimTypes.NameIdentifier)?.Value;

            request.UserId = id;

            var res = await _mediator.Send(request);
            return Ok(res);
        }

        [HttpGet]
        public async Task<IActionResult> GetAll([FromQuery] GetAllPostsQueryRequest request)
        {
            var res = await _mediator.Send(request);
            return Ok(res);
        }

        [HttpGet("myPosts")]
        public async Task<IActionResult> GetMyPosts([FromQuery] GetMyPostsQueryRequest request)
        {
            var _bearer_token = Request.Headers[HeaderNames.Authorization].ToString().Replace("Bearer ", "");
            var handler = new JwtSecurityTokenHandler();
            var jwtSecurityToken = handler.ReadJwtToken(_bearer_token);
            var id = jwtSecurityToken.Claims.FirstOrDefault(x => x.Type == ClaimTypes.NameIdentifier)?.Value;


            request.UserId = id;

            var res = await _mediator.Send(request);
            return Ok(res);
        }
    }
}