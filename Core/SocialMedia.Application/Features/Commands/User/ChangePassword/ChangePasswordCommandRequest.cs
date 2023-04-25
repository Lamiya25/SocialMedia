using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SocialMedia.Application.Features.Commands.User.ChangePassword
{
    public class ChangePasswordCommandRequest : IRequest<ChangePasswordCommandResponse>
    {
        public string UserId { get; set; }
        public string NewPassword { get; set; }
    }
}
