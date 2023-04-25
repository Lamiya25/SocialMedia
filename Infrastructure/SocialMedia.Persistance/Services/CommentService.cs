using FluentValidation.Results;
using SocialMedia.Application.Abstractions.Services;
using SocialMedia.Application.DTOs.Comment;
using SocialMedia.Application.Features.Commands.Comment.Create;
using SocialMedia.Application.Repositories.Comments;
using SocialMedia.Application.Validators;
using SocialMedia.Domain.Entities;

namespace SocialMedia.Persistance.Services
{
    public class CommentService : ICommentService
    {
        private readonly ICommentWriteRepository _commentWriteRepo;
        private readonly ICommentReadRepository _commentReadRepo;
        public CommentService(ICommentWriteRepository commentWriteRepo, ICommentReadRepository commentReadRepo)
        {
            _commentWriteRepo = commentWriteRepo;
            _commentReadRepo = commentReadRepo;
        }

        public async Task<CreateCommentCommandResponse> CreateCommentAsync(CreateCommentDto comment)
        {
            Comment commentEntity = await _commentWriteRepo.AddEntityAsync(new()
            {
                Id = Guid.NewGuid().ToString(),
                PostId = comment.PostId,
                UserId = comment.UserId,
                Content = comment.Content
            });

            ValidationResult result = await ValidateCommentAsync(commentEntity);

            if (result.IsValid)
            {
                await _commentWriteRepo.SaveAsync();
                return new() { Succeeded = true };
            }

            return new() { Succeeded = false, Errors = result.Errors.Select(x => x.ErrorMessage).ToList() };
        }

        public async Task DeleteCommentAsync(string commentId)
        {
            await _commentWriteRepo.RemoveAsync(commentId);
            await _commentWriteRepo.SaveAsync();
        }

        private async Task<ValidationResult> ValidateCommentAsync(Comment comment)
        {
            CommentValidator validationRules = new();
            return await validationRules.ValidateAsync(comment);
        }

    }
}