using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SocialMedia.Domain.Entities
{
    public class PostImage : BaseFile
    {
        public Post Post { get; set; }
        public string PostId { get; set; }
    }
}