using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SocialMedia.Application.Abstractions.Services
{
    public interface IPostReactionService
    {
        Task LikePostAsync(string userId, string postId);
        int GetPostReactions(string postId);
    }
}