using MediatR;
using SocialMedia.Application.Abstractions.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SocialMedia.Application.Features.Commands.Post.Edit
{
    public class EditPostCommandHandler : IRequestHandler<EditPostCommandRequest, EditPostCommandResponse>
    {
        private readonly IPostService _postService;
        public EditPostCommandHandler(IPostService postService)
        {
            _postService = postService;
        }

        public async Task<EditPostCommandResponse> Handle(EditPostCommandRequest request, CancellationToken cancellationToken)
        {
            return await _postService.EditPostAsync(request.EditPostDto);
        }
    }
}