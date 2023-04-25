using MediatR;
using SocialMedia.Application.Abstractions.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SocialMedia.Application.Features.Commands.Post.Create
{
    public class PostCreateCommandHandler : IRequestHandler<PostCreateCommandRequest, PostCreateCommandResponse>
    {
        private readonly IPostService _postService;
        public PostCreateCommandHandler(IPostService postService)
        {
            _postService = postService;
        }

        public async Task<PostCreateCommandResponse> Handle(PostCreateCommandRequest request, CancellationToken cancellationToken)
        {
            return await _postService.CreatePostAsync(request.CreatePostDto);
        }
    }
}