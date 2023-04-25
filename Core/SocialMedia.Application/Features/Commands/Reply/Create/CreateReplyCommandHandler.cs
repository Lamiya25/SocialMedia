using MediatR;
using SocialMedia.Application.Abstractions.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SocialMedia.Application.Features.Commands.Reply.Create
{
    public class CreateReplyCommandHandler : IRequestHandler<CreateReplyCommandRequest, CreateReplyCommandResponse>
    {
        private readonly IReplyService _replyService;
        public CreateReplyCommandHandler(IReplyService replyService)
        {
            _replyService = replyService;
        }

        public async Task<CreateReplyCommandResponse> Handle(CreateReplyCommandRequest request, CancellationToken cancellationToken)
        {
            return await _replyService.CreateReplyAsync(request.CreateReplyDto);
        }
    }
}