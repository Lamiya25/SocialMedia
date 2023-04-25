using SocialMedia.Application.DTOs.Reply;
using SocialMedia.Application.Features.Commands.Reply.Create;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SocialMedia.Application.Abstractions.Services
{
    public interface IReplyService
    {
        Task<CreateReplyCommandResponse> CreateReplyAsync(CreateReplyDto reply);
        Task DeleteReplyAsync(string commentId);
    }
}