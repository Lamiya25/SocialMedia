using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SocialMedia.Domain.Common
{
    public class BaseEntity
    {
        public string Id { get; set; }
        public bool IsDeleted { get; set; }
        public virtual DateTime Date { get; set; }
    }
}