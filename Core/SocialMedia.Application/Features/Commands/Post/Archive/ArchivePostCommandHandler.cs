using MediatR;
using SocialMedia.Application.Abstractions.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SocialMedia.Application.Features.Commands.Post.Archive
{
    public class ArchivePostCommandHandler : IRequestHandler<ArchivePostCommandRequest, ArchivePostCommandResponse>
    {
        private readonly IPostService _postService;
        public ArchivePostCommandHandler(IPostService postService)
        {
            _postService = postService;
        }

        public async Task<ArchivePostCommandResponse> Handle(ArchivePostCommandRequest request, CancellationToken cancellationToken)
        {
            await _postService.ToggleArchivePostAsync(request.Id);
            return new() { Succeeded = true };
        }
    }
}