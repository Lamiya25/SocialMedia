using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SocialMedia.Application.DTOs.Reply
{
    public class CreateReplyDto
    {
        public string UserId { get; set; }
        public string CommentId { get; set; }
        public string Content { get; set; }
    }
}