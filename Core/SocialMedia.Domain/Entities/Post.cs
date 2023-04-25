using SocialMedia.Domain.Common;
using SocialMedia.Domain.Entities.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SocialMedia.Domain.Entities
{
    public class Post : BaseEntity
    {
        public string? Content { get; set; }
        public ICollection<PostImage>? PostImages { get; set; }
        public User User { get; set; }
        public string UserId { get; set; }
        public ICollection<PostReaction> PostReactions { get; set; }
        public ICollection<Comment> Comments { get; set; }
    }
}