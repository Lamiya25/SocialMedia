using SocialMedia.Application.DTOs.Comment;
using SocialMedia.Application.Features.Commands.Comment.Create;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SocialMedia.Application.Abstractions.Services
{
    public interface ICommentService
    {
        Task<CreateCommentCommandResponse> CreateCommentAsync(CreateCommentDto comment);
        Task DeleteCommentAsync(string commentId);
    }
}