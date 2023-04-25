using MediatR;
using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SocialMedia.Application.Features.Commands.User.UploadProfileImage
{
    public class UploadPICommandRequest : IRequest<UploadPICommandResponse>
    {
        public string UserId { get; set; }
        public IFormFile File { get; set; }
    }
}