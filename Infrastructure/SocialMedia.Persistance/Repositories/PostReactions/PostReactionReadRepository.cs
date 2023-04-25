﻿using SocialMedia.Application.Repositories.PostReactions;
using SocialMedia.Domain.Entities;
using SocialMedia.Persistance.Contexts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SocialMedia.Persistance.Repositories.Comments
{
    public class PostReactionReadRepository : ReadRepository<PostReaction>, IPostReactionReadRepository
    {
        public PostReactionReadRepository(AppDbContext context) : base(context)
        {
        }
    }
}