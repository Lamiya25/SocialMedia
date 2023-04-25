using SocialMedia.Application.DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SocialMedia.Application.Features.Commands.Auth.GoogleLogin
{
    public class GoogleLoginCommandResponse : BaseCommandResponse
    {
        public Token Token { get; set; }
    }
}