using SocialMedia.Domain.Common;
using SocialMedia.Domain.Entities.Identity;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SocialMedia.Domain.Entities
{
    public class PostReaction : BaseEntity
    {
        public string UserId { get; set; }
        public User User { get; set; }
        public Post Post { get; set; }
        public string PostId { get; set; }
        public bool IsLike { get; set; }

        [NotMapped]
        public override DateTime Date { get => base.Date; set => base.Date = value; }
    }
}