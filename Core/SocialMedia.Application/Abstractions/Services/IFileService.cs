using Microsoft.AspNetCore.Http;
using SocialMedia.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SocialMedia.Application.Abstractions.Services
{
    public interface IFileService
    {
        Task<List<PostImage>> WritePostImagesAsync(string postId, IFormFileCollection files);
        Task<ProfileImage> WriteProfileImageAsync(IFormFile file);
        Task DeletePostImageAsync(string postImageId);
    }
}