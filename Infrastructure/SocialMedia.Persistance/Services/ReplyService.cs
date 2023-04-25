using FluentValidation.Results;
using SocialMedia.Application.Abstractions.Services;
using SocialMedia.Application.DTOs.Reply;
using SocialMedia.Application.Features.Commands.Comment.Create;
using SocialMedia.Application.Features.Commands.Reply.Create;
using SocialMedia.Application.Repositories.Replies;
using SocialMedia.Application.Validators;
using SocialMedia.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SocialMedia.Persistance.Services
{
    public class ReplyService : IReplyService
    {
        private readonly IReplyWriteRepository _replyWriteRepo;
        private readonly IReplyReadRepository _replyReadRepo;
        public ReplyService(IReplyWriteRepository replyWriteRepo, IReplyReadRepository replyReadRepo)
        {
            _replyWriteRepo = replyWriteRepo;
            _replyReadRepo = replyReadRepo;
        }

        public async Task<CreateReplyCommandResponse> CreateReplyAsync(CreateReplyDto reply)
        {
            Reply commentEntity = await _replyWriteRepo.AddEntityAsync(new()
            {
                Id = Guid.NewGuid().ToString(),
                CommentId = reply.CommentId,
                UserId = reply.UserId,
                Content = reply.Content
            });

            ValidationResult result = await ValidateCommentAsync(commentEntity);

            if (result.IsValid)
            {
                await _replyWriteRepo.SaveAsync();
                return new() { Succeeded = true };
            }

            return new() { Succeeded = false, Errors = result.Errors.Select(x => x.ErrorMessage).ToList() };
        }

        private async Task<ValidationResult> ValidateCommentAsync(Reply reply)
        {
            ReplyValidator validationRules = new();
            return await validationRules.ValidateAsync(reply);
        }
        public async Task DeleteReplyAsync(string commentId)
        {
            await _replyWriteRepo.RemoveAsync(commentId);
            await _replyWriteRepo.SaveAsync();
        }
    }
}