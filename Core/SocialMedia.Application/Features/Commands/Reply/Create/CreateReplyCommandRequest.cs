using MediatR;
using SocialMedia.Application.DTOs.Reply;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SocialMedia.Application.Features.Commands.Reply.Create
{
    public class CreateReplyCommandRequest : IRequest<CreateReplyCommandResponse>
    {
        public CreateReplyDto CreateReplyDto { get; set; }
    }
}