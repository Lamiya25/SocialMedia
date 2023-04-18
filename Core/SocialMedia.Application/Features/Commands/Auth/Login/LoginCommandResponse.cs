using SocialMedia.Application.DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SocialMedia.Application.Features.Commands.Auth.Login
{
    public class LoginCommandResponse
    {
        public bool Succeeded { get; set; }
        public Token Token { get; set; }

        public List<string> Errors { get; set; }
    }
}
