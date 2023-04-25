using MediatR;
using SocialMedia.Application.Abstractions.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SocialMedia.Application.Features.Commands.Comment.Delete
{
    public class DeleteCommentCommandHandler : IRequestHandler<DeleteCommentCommandRequest, DeleteCommentCommandResponse>
    {
        private readonly ICommentService _commentService;
        public DeleteCommentCommandHandler(ICommentService commentService)
        {
            _commentService = commentService;
        }

        public async Task<DeleteCommentCommandResponse> Handle(DeleteCommentCommandRequest request, CancellationToken cancellationToken)
        {
            await _commentService.DeleteCommentAsync(request.CommentId);
            return new() { Succeeded = true };
        }
    }
}