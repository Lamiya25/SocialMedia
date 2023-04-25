using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SocialMedia.Application.Features.Queries.Post.GetAll
{
    public class GetMyPostsQueryRequest : IRequest<GetMyPostsQueryResponse>
    {
        public string? UserId { get; set; }
        public int Size { get; set; } = 5;
        public int Page { get; set; } = 0;
    }
}