using SocialMedia.Domain.Common;
using SocialMedia.Domain.Entities.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SocialMedia.Domain.Entities
{
    public class Reply : BaseEntity
    {
        public User User { get; set; }
        public string UserId { get; set; }
        public Comment Comment { get; set; }
        public string CommentId { get; set; }
        public string Content { get; set; }
    }
}