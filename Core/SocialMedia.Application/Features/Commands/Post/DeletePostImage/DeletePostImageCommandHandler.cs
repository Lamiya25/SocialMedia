using MediatR;
using SocialMedia.Application.Abstractions.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SocialMedia.Application.Features.Commands.Post.DeletePostImage
{
    public class DeletePostImageCommandHandler : IRequestHandler<DeletePostImageCommandRequest, DeletePostImageCommandResponse>
    {
        private readonly IPostService _postService;
        public DeletePostImageCommandHandler(IPostService postService)
        {
            _postService = postService;
        }

        public async Task<DeletePostImageCommandResponse> Handle(DeletePostImageCommandRequest request, CancellationToken cancellationToken)
        {
            await _postService.DeletePostImageAsync(request.Id);
            return new() { Succeeded = true };
        }
    }
}