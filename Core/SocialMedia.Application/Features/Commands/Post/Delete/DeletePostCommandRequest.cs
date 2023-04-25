using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SocialMedia.Application.Features.Commands.Post.Delete
{
    public class DeletePostCommandRequest : IRequest<DeletePostCommandResponse>
    {
        public string Id { get; set; }
    }
}