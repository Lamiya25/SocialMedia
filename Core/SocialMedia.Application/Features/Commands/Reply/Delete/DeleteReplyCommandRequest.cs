using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SocialMedia.Application.Features.Commands.Reply.Delete
{
    public class DeleteReplyCommandRequest : IRequest<DeleteReplyCommandResponse>
    {
        public string ReplyId { get; set; }
    }
}