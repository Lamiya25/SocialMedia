using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SocialMedia.Application.Features.Commands.User.AssignRole
{
    public class AssignRoleCommandRequest : IRequest<AssignRoleCommandResponse>
    {
        public string UserId { get; set; }
        public string RoleType { get; set; }
    }
}