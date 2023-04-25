using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SocialMedia.Application.Features.Commands.User.ChangeVisibility
{
    public class ChangeVisibilityCommandRequest : IRequest<ChangeVisibilityCommandResponse>
    {
        public string UserId { get; set; }
    }
}