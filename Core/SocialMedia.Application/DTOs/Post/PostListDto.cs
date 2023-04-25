using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SocialMedia.Application.DTOs.Post
{
    public class PostListDto
    {
        public string Id { get; set; }
        public string UserId { get; set; }
        public string? Content { get; set; }
        public IEnumerable<string>? Files { get; set; }
        public IEnumerable<Domain.Entities.Comment>? Comments { get; set; }
        public int Likes { get; set; }

    }
}