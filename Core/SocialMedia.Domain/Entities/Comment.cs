using SocialMedia.Domain.Common;
using SocialMedia.Domain.Entities.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SocialMedia.Domain.Entities
{
    public class Comment : BaseEntity
    {
        public Post Post { get; set; }
        public string PostId { get; set; }
        public User User { get; set; }
        public string UserId { get; set; }
        public string Content { get; set; }
        public ICollection<Reply> Replies { get; set; }
    }
}