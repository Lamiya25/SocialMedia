using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;

namespace SocialMedia.Application.Features.Commands.User.Create
{
    public class CreateUserCommandResponse
    {
        public bool Succeeded { get; set; }

        public List<string> Errors { get; set; }
    }
}
