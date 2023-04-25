using MediatR;
using SocialMedia.Application.Abstractions.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SocialMedia.Application.Features.Commands.PostReaction
{
    public class LikePostCommandHandler : IRequestHandler<LikePostCommandRequest, LikePostCommandResponse>
    {
        private readonly IPostReactionService _postReactionService;
        public LikePostCommandHandler(IPostReactionService postReactionService)
        {
            _postReactionService = postReactionService;
        }

        public async Task<LikePostCommandResponse> Handle(LikePostCommandRequest request, CancellationToken cancellationToken)
        {
            await _postReactionService.LikePostAsync(request.UserId, request.PostId);
            return new() { Succeeded = true };
        }
    }
}