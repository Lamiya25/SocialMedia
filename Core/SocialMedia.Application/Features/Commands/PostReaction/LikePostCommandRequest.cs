using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SocialMedia.Application.Features.Commands.PostReaction
{
    public class LikePostCommandRequest : IRequest<LikePostCommandResponse>
    {
        public string UserId { get; set; }
        public string PostId { get; set; }
    }
}