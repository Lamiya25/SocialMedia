using MediatR;
using SocialMedia.Application.Abstractions.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SocialMedia.Application.Features.Queries.Post.GetAll
{
    public class GetAllPostsQueryHandler : IRequestHandler<GetAllPostsQueryRequest, GetAllPostsQueryResponse>
    {
        private readonly IPostService _postService;
        public GetAllPostsQueryHandler(IPostService postService)
        {
            _postService = postService;
        }

        public async Task<GetAllPostsQueryResponse> Handle(GetAllPostsQueryRequest request, CancellationToken cancellationToken)
        {
            return await _postService.GetAllPostsAsync(request.Page, request.Size);
        }
    }
}