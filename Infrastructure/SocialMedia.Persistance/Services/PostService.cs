using FluentValidation.Results;
using Microsoft.AspNetCore.Http;
using Microsoft.EntityFrameworkCore;
using SocialMedia.Application.Abstractions.Caching;
using SocialMedia.Application.Abstractions.Services;
using SocialMedia.Application.Consts;
using SocialMedia.Application.DTOs.Post;
using SocialMedia.Application.Features.Commands.Post.Create;
using SocialMedia.Application.Features.Commands.Post.Edit;
using SocialMedia.Application.Features.Queries.Post.GetAll;
using SocialMedia.Application.Validators;
using SocialMedia.Domain.Entities;
using System.Text.Json;
using SocialMedia.Application.Enums;
using SocialMedia.Application.Repositories.PostReactions;

namespace SocialMedia.Persistance.Services
{
    public class PostService : IPostService
    {
        private readonly IPostWriteRepository _postWriteRepo;
        private readonly IPostReadRepository _postReadRepo;
        private readonly IFileService _fileService;
        private readonly IPostReactionService _postReactionService;
        private readonly ICacheService _cacheService;
        public PostService(IPostWriteRepository postWriteRepo, IFileService fileService, IPostReadRepository postReadRepo, IPostReactionService postReactionService, ICacheService cacheService)
        {
            _postWriteRepo = postWriteRepo;
            _fileService = fileService;
            _postReadRepo = postReadRepo;
            _postReactionService = postReactionService;
            _cacheService = cacheService;
        }

        public async Task ToggleArchivePostAsync(string id)
        {
            Post post = await _postReadRepo.GetByIdAsync(id);
            post.IsDeleted = !post.IsDeleted;
            _postWriteRepo.Update(post);
            await _postWriteRepo.SaveAsync();
        }

        public async Task<PostCreateCommandResponse> CreatePostAsync(CreatePostDto post)
        {
            Post postEntity = await _postWriteRepo.AddEntityAsync(new()
            {
                Id = Guid.NewGuid().ToString(),
                Content = post.Content,
                UserId = post.UserId,
            });

            ValidationResult validationResults = await ValidatePostAsync(postEntity);


            if (IsPostValid(postEntity.Content, post.Files))
            {

                if (validationResults.IsValid)
                {
                    await _postWriteRepo.SaveAsync();

                    if (post.Files is not null)
                        await _fileService.WritePostImagesAsync(postEntity.Id, post.Files);

                    return new() { Succeeded = validationResults.IsValid };
                }
                return new()
                {
                    Succeeded = validationResults.IsValid,
                    Errors = validationResults.Errors.Select(x => x.ErrorMessage).ToList()
                };
            }

            return new() { Succeeded = false, Errors = new List<string>() { Messages.EmptyPostMessage } };

        }

        public async Task<bool> DeletePostAsync(string id)
        {
            bool res = await _postWriteRepo.RemoveAsync(id);
            await _postWriteRepo.SaveAsync();
            return res;
        }

        public async Task DeletePostImageAsync(string id)
        {
            await _fileService.DeletePostImageAsync(id);
        }

        public async Task<EditPostCommandResponse> EditPostAsync(EditPostDto post)
        {
            Post currentPost = await _postReadRepo.GetByIdAsync(post.Id);

            if (IsPostValid(post.Content, post.Files))
            {
                if (post.Files is not null)
                {
                    List<PostImage> postImages = await _fileService.WritePostImagesAsync(currentPost.Id, post.Files);
                    currentPost.PostImages = postImages;
                }

                currentPost.Content = post.Content ?? currentPost.Content;

                ValidationResult validationResult = await ValidatePostAsync(currentPost);
                if (validationResult.IsValid)
                {
                    _postWriteRepo.Update(currentPost);
                    await _postWriteRepo.SaveAsync();
                    return new() { Succeeded = true };
                }
                return new()
                {
                    Succeeded = true,
                    Errors = validationResult.Errors.Select(x => x.ErrorMessage).ToList()
                };
            }

            return new() { Succeeded = false, Errors = new List<string>() { Messages.EmptyPostMessage } };


        }

        private bool IsPostValid(string content, IFormFileCollection files) => !(content is null && files is null);

        private async Task<ValidationResult> ValidatePostAsync(Post post)
        {
            PostValidator validationRules = new();
            return await validationRules.ValidateAsync(post);
        }

        public async Task<GetAllPostsQueryResponse> GetAllPostsAsync(int page = 0, int size = 5)
        {
            string cachedData = await _cacheService.GetStringAsync(KeysForCaching.Posts);
            if (cachedData is not null)
            {
                var res = JsonSerializer.Deserialize<List<PostListDto>>(cachedData);
                return new() { Succeeded = true, Values = res };
            }

            var posts = await _postReadRepo.GetAll().Include(x => x.PostImages).Include(x => x.Comments)
                .ThenInclude(x => x.Replies)
                .Select(x => new PostListDto()
                {
                    Id = x.Id,
                    UserId = x.UserId,
                    Content = x.Content,
                    Files = x.PostImages.Select(x => x.Path),
                    Comments = x.Comments,
                    Likes = _postReactionService.GetPostReactions(x.Id)
                })
                .Skip(page * size)
                .Take(size)
                .ToListAsync();

            await CachePostsAsync(posts, KeysForCaching.Posts);

            if (!posts.Any())
                return new() { Succeeded = false, Errors = new List<string>() { Messages.NoPostsFoundMessage } };

            return new() { Succeeded = true, Values = posts };
        }

        private async Task CachePostsAsync(List<PostListDto> posts, string key)
        {
            //Store cache
            string jsonValue = JsonSerializer.Serialize(posts);
            await _cacheService.SetStringAsync(key, jsonValue, 30, CacheExpirationType.AbsoluteExpiration);
        }

        public async Task<GetMyPostsQueryResponse> GetMyPostsAsync(string userId, int page = 0, int size = 5)
        {
            string myCachedPosts = await _cacheService.GetStringAsync(KeysForCaching.MyPosts);

            if (myCachedPosts != null)
            {
                List<PostListDto> values = JsonSerializer.Deserialize<List<PostListDto>>(myCachedPosts);
                return new() { Succeeded = true, Values = values };
            }

            var posts = await _postReadRepo.GetAllWhere(x => x.UserId == userId).Include(x => x.PostImages)
                .Include(x => x.Comments)
                .ThenInclude(x => x.Replies)
                .Select(x => new PostListDto()
                {
                    Id = x.Id,
                    UserId = x.UserId,
                    Content = x.Content,
                    Files = x.PostImages.Select(x => x.Path),
                    Comments = x.Comments,
                    Likes = _postReactionService.GetPostReactions(x.Id)
                })
                .Skip(page * size)
                .Take(size)
                .ToListAsync();

            await CachePostsAsync(posts, KeysForCaching.MyPosts);

            if (!posts.Any())
                return new() { Succeeded = false, Errors = new List<string>() { Messages.NoPostsFoundMessage } };

            return new() { Succeeded = true, Values = posts };
        }
    }
}
