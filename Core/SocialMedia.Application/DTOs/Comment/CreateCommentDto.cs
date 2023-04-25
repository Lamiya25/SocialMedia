using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SocialMedia.Application.DTOs.Comment
{
    public class CreateCommentDto
    {
        public string? UserId { get; set; }
        public string PostId { get; set; }
        public string Content { get; set; }
    }
}