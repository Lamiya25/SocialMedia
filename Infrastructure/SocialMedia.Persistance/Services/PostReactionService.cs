using Microsoft.EntityFrameworkCore;
using SocialMedia.Application.Abstractions.Services;
using SocialMedia.Application.Repositories.PostReactions;
using SocialMedia.Domain.Entities;
using SocialMedia.Persistance.Contexts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SocialMedia.Persistance.Services
{
    public class PostReactionService : IPostReactionService
    {
        private readonly IPostReactionReadRepository _postReactionRead;
        private readonly IPostReactionWriteRepository _postReactionWrite;
        private readonly AppDbContext _context;
        public PostReactionService(IPostReactionReadRepository postReactionRead, IPostReactionWriteRepository postReactionWrite, AppDbContext context)
        {
            _postReactionRead = postReactionRead;
            _postReactionWrite = postReactionWrite;
            _context = context;
        }



        public int GetPostReactions(string postId)
        {
            IEnumerable<PostReaction> postReactions = _postReactionRead
                                .GetAllWhere(x => x.PostId == postId && x.IsLike == true)
                                .ToList();
            return postReactions.Count();
        }

        public async Task LikePostAsync(string userId, string postId)
        {
            if (!await IsAlreadyLikedAsync(userId, postId))
            {
                await _postReactionWrite.AddEntityAsync(new()
                {
                    Id = Guid.NewGuid().ToString(),
                    UserId = userId,
                    PostId = postId,
                    IsLike = true,
                });
            }
            else
            {
                PostReaction postReaction = await _postReactionRead.GetAsync(x => x.UserId == userId && x.PostId == postId);
                postReaction.IsLike = !postReaction.IsLike;
            }

            await _postReactionWrite.SaveAsync();
        }

        private async Task<bool> IsAlreadyLikedAsync(string userId, string postId)
            => await _context.PostReactions.AnyAsync(x => x.UserId == userId && x.PostId == postId);




    }
}