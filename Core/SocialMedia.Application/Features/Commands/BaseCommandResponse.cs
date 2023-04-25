using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SocialMedia.Application.Features.Commands
{
    public class BaseCommandResponse
    {
        public bool Succeeded { get; set; }
        public List<string> Errors { get; set; }
    }
}
