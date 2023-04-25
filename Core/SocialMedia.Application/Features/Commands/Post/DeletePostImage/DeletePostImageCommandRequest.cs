using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SocialMedia.Application.Features.Commands.Post.DeletePostImage
{
    public class DeletePostImageCommandRequest : IRequest<DeletePostImageCommandResponse>
    {
        public string Id { get; set; }
    }
}