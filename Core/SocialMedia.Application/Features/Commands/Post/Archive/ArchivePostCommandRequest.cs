using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SocialMedia.Application.Features.Commands.Post.Archive
{
    public class ArchivePostCommandRequest : IRequest<ArchivePostCommandResponse>
    {
        public string Id { get; set; }
    }
}