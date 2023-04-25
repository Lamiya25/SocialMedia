using MediatR;
using SocialMedia.Application.Abstractions.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SocialMedia.Application.Features.Commands.Reply.Delete
{
    public class DeleteReplyCommandHandler : IRequestHandler<DeleteReplyCommandRequest, DeleteReplyCommandResponse>
    {
        private readonly IReplyService _replyService;
        public DeleteReplyCommandHandler(IReplyService replyService)
        {
            _replyService = replyService;
        }

        public async Task<DeleteReplyCommandResponse> Handle(DeleteReplyCommandRequest request, CancellationToken cancellationToken)
        {
            await _replyService.DeleteReplyAsync(request.ReplyId);
            return new() { Succeeded = true };
        }
    }
}