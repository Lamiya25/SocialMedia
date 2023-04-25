using MediatR;
using SocialMedia.Application.DTOs.Comment;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SocialMedia.Application.Features.Commands.Comment.Create
{
    public class CreateCommentCommandRequest : IRequest<CreateCommentCommandResponse>
    {
        public CreateCommentDto CreateCommentDto { get; set; }
    }
}