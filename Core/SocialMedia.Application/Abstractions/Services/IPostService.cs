using Microsoft.AspNetCore.Http;
using SocialMedia.Application.DTOs.Post;
using SocialMedia.Application.Features.Commands.Post.Archive;
using SocialMedia.Application.Features.Commands.Post.Create;
using SocialMedia.Application.Features.Commands.Post.Edit;
using SocialMedia.Application.Features.Queries.Post.GetAll;


namespace SocialMedia.Application.Abstractions.Services
{
    public interface IPostService
    {
        Task<PostCreateCommandResponse> CreatePostAsync(CreatePostDto post);
        Task<EditPostCommandResponse> EditPostAsync(EditPostDto post);
        Task DeletePostImageAsync(string id);
        Task<bool> DeletePostAsync(string id);
        Task ToggleArchivePostAsync(string id);
        Task<GetAllPostsQueryResponse> GetAllPostsAsync(int page = 0, int size = 5);
        Task<GetMyPostsQueryResponse> GetMyPostsAsync(string userId, int page = 0, int size = 5);
    }
}