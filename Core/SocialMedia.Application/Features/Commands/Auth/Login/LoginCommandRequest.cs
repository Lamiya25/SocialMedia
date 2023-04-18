using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SocialMedia.Application.Features.Commands.Auth.Login
{
    public class LoginCommandRequest:IRequest<LoginCommandResponse>
    {
        public string usernameOremail { get; set; }

        public string Password { get; set; }
    }
}
