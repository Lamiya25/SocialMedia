using SocialMedia.Domain.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SocialMedia.Domain.Entities
{
    public class Post : BaseEntity
    {
        public string Content { get; set; }
    }
}
