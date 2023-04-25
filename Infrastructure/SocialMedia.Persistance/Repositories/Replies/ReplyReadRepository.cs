using SocialMedia.Application.Repositories.Replies;
using SocialMedia.Domain.Entities;
using SocialMedia.Persistance.Contexts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SocialMedia.Persistance.Repositories.Comments
{
    public class ReplyReadRepository : ReadRepository<Reply>, IReplyReadRepository
    {
        public ReplyReadRepository(AppDbContext context) : base(context)
        {
        }
    }
}