using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SocialMedia.Application.DTOs.Post
{
    public class CreatePostDto
    {
        public string? Content { get; set; }
        public string? UserId { get; set; }
        public IFormFileCollection? Files { get; set; }
    }
}