using MediatR;
using SocialMedia.Application.Abstractions.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SocialMedia.Application.Features.Queries.Post.GetAll
{

    public class GetMyPostsQueryHandler : IRequestHandler<GetMyPostsQueryRequest, GetMyPostsQueryResponse>
    {
        private readonly IPostService _postService;
        public GetMyPostsQueryHandler(IPostService postService)
        {
            _postService = postService;
        }

        public async Task<GetMyPostsQueryResponse> Handle(GetMyPostsQueryRequest request, CancellationToken cancellationToken)
        {
            return await _postService.GetMyPostsAsync(request.UserId, request.Page, request.Size);
        }
    }
}