using SocialMedia.Application.Repositories.PostImages;
using SocialMedia.Domain.Entities;
using SocialMedia.Persistance.Contexts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SocialMedia.Persistance.Repositories.Comments
{
    public class PostImageReadRepository : ReadRepository<PostImage>, IPostImageReadRepository
    {
        public PostImageReadRepository(AppDbContext context) : base(context)
        {
        }
    }
}
