using MediatR;
using SocialMedia.Application.Abstractions.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SocialMedia.Application.Features.Commands.Post.Delete
{
    public class DeletePostCommandHandler : IRequestHandler<DeletePostCommandRequest, DeletePostCommandResponse>
    {
        private readonly IPostService _postService;
        public DeletePostCommandHandler(IPostService postService)
        {
            _postService = postService;
        }

        public async Task<DeletePostCommandResponse> Handle(DeletePostCommandRequest request, CancellationToken cancellationToken)
        {
            bool res = await _postService.DeletePostAsync(request.Id);
            return new() { Succeeded = res };
        }
    }
}